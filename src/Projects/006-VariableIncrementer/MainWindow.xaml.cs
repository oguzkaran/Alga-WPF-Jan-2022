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

namespace VariableIncrementer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int m_value;
        private List<int> m_list = new();
        
        private void thread1Callback()
        {
            for (int i = 0; i < 1000000; ++i)
                lock (this)
                {
                    ++m_value;
                    m_list.Add(i);
                }
        }

        private void thread2Callback()
        {
            for (int i = 0; i < 1000000; ++i)
                lock (this)
                {
                    --m_value;
                    m_list.Add(i);
                }
        }

        private void threadCallback()
        {
            var thread1 = new Thread(thread1Callback);
            var thread2 = new Thread(thread2Callback);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Dispatcher.BeginInvoke((Action)(() => Title = $"m_value:{m_value}, Count:{m_list.Count}"));
        }

        public MainWindow()
        {
            InitializeComponent();
            onOKButtonClicked(null, null);
        }

        private void onOKButtonClicked(object sender, RoutedEventArgs e)
        {
            var thread = new Thread(threadCallback);

            thread.IsBackground = true;
            thread.Start();
        }
    }
}
