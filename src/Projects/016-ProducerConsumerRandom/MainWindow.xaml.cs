using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using static CSD.Util.Async.ThreadUtil;

namespace _015_ProducerConsumerRandom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int QSize = 10;
        private Random m_random;
        private Semaphore m_semProducer, m_semConsumer;
        private Queue<int> m_queue;
        private SynchronizationContext m_sc;

        public MainWindow()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            m_random = new();
            m_semProducer = new(QSize, QSize);
            m_semConsumer = new(0, QSize);
            m_queue = new();
            m_sc = SynchronizationContext.Current;
        }

        private void producerThreadCallback(int count)
        {

            int i = 1;

            while (true)
            {
                m_semProducer.WaitOne();
                lock (m_queue)
                    m_queue.Enqueue(i);
                m_semConsumer.Release();

                if (i == count)
                    break;

                ++i;
            }

        }

        private void consumerThreadCallback(int count)
        {            
            int val;
            int sum = 0;

            while (true)
            {
                m_semConsumer.WaitOne();
                lock (m_queue)
                    val = m_queue.Dequeue();

                m_semProducer.Release();

                sum += val;
                
                if (val == count)
                    break;             
            }

            m_sc.Post(value => m_labelValues.Content = value, sum);
            m_sc.Post(_ => m_buttonStart.IsEnabled = true, null);
        }

        private void waitThreadProc(object obj)
        {
#if DEBUG
            var stopWatch = new Stopwatch();

            stopWatch.Start();
#endif
            int count = (int)obj;

            var tp = CreateThread(_ => producerThreadCallback(count));

            tp.Start();

            var tc = CreateThread(_ => consumerThreadCallback(count));

            tc.Start();

#if DEBUG
            tp.Join();
            tc.Join();
            stopWatch.Stop();
            m_sc.Post(_ => Title = stopWatch.ElapsedMilliseconds.ToString(), null);
#endif
        }

        private void m_buttonStart_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(m_textBoxCount.Text, out int count)) {
                MessageBox.Show("Invalid Values");
                return;
            }

            m_buttonStart.IsEnabled = false;
            CreateThread(waitThreadProc).Start(count);
        }
    }
}
