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
        private EventWaitHandle m_eventProducer, m_eventConsumer;
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
            m_eventProducer = new(true, EventResetMode.AutoReset);
            m_eventConsumer = new(false, EventResetMode.AutoReset);
            m_sc = SynchronizationContext.Current;
        }

        private void producerThreadCallback()
        {
            int i = 0;

            while (true) {
                Thread.Sleep(m_random.Next(500));
                m_eventProducer.WaitOne();
                m_shared = i;
                m_eventConsumer.Set();

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
                m_eventConsumer.WaitOne();
                val = m_shared;
                m_eventProducer.Set();
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
