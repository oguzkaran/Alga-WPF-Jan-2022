using System;
using System.Collections.Generic;
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

namespace ProducerConsumerEventWaitHandle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random m_random;
        private Semaphore m_semProducer, m_semConsumer;
        private int m_shared;
        private SynchronizationContext m_sc;

        public MainWindow()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            m_random = new();
            m_semProducer = new(1, 1);
            m_semConsumer = new(0, 1);
            m_sc = SynchronizationContext.Current;
        }

        private void producerThreadCallback()
        {
            int i = 0;

            while (true) {
                Thread.Sleep(m_random.Next(500));
                m_semProducer.WaitOne();
                m_shared = i;
                m_semConsumer.Release();

                if (i == 99)
                    break;

                ++i;
            }
        }

        private void consumerThreadCallback()
        {
            var sb = new StringBuilder();
            int val;

            while (true) {
                m_semConsumer.WaitOne();
                val = m_shared;
                m_semProducer.Release();

                if (sb.ToString() != "")
                    sb.Append('-');

                sb.Append(val);

                m_sc.Post(s => m_labelValues.Content = s, sb.ToString());
                if (val == 99)
                    break;

                Thread.Sleep(m_random.Next(500));                
            }

            m_sc.Post(_ => m_buttonStart.IsEnabled = true, null);
        }


        private void m_buttonStart_Click(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(_ => producerThreadCallback());
            ThreadPool.QueueUserWorkItem(_ => consumerThreadCallback());

            m_buttonStart.IsEnabled = false;
        }
    }
}
