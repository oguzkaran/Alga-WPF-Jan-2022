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

namespace SimpleCounter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread m_counterThread;
        private SynchronizationContext m_sc;

        private void clockTimerCallback()
        {
            //UI Thread'e mesaj gönderiliyor. Yani işlem UI thread içerisinde yapılıyor
            Dispatcher.BeginInvoke((Action)(() => Title = DateTime.Now.ToString())); 
        }

        private void setContent(object count)
        {
            m_labelCounter.Content = count.ToString();
        }

        private void counterThreadCallback(object o)
        {
            var count = (int)o;            

            while (true) {
                ++count;                
                m_sc.Post(setContent, count);                
                Thread.Sleep(1000);
            }
        }

        private void initClock()
        {
            new Timer(_ => clockTimerCallback(), null, 0, 1000);
        }

        private void init()
        {
            m_sc = SynchronizationContext.Current;
            initClock();
        }

        public MainWindow()
        {
            InitializeComponent();
            init();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            ThreadPool.QueueUserWorkItem(counterThreadCallback, 0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
