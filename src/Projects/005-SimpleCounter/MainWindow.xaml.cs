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

        private void clockTimerCallback()
        {
            //UI Thread'e mesaj gönderiliyor. Yani işlem UI thread içerisinde yapılıyor
            Dispatcher.BeginInvoke((Action)(() => Title = DateTime.Now.ToString())); 
        }

        private void setContent(int count)
        {
            m_labelCounter.Content = count;
        }

        private void counterThreadCallback(object o)
        {
            var count = (int)o;
            Action<int> action = setContent;

            while (true) {
                ++count;
                Dispatcher.BeginInvoke(action, count);
                Thread.Sleep(1000);
            }
        }


        private void initClock()
        {
            new Timer(_ => clockTimerCallback(), null, 0, 1000);
        }

        private void init()
        {
            initClock();
        }

        public MainWindow()
        {
            InitializeComponent();
            init();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (m_counterThread != null)
                m_counterThread.Interrupt();

            m_counterThread = new Thread(counterThreadCallback);

            m_counterThread.Start(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
