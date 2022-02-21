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

namespace RandomNumberGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SynchronizationContext m_sc;

        public MainWindow()
        {
            InitializeComponent();
            m_sc = SynchronizationContext.Current;
        }

        private int randomGeneratorThreadCallback(object obj)
        {
            var sum = 0;

            try
            {
                var param = (Tuple<int, int, int>)obj;

                var min = param.Item1;
                var max = param.Item2;
                var count = param.Item3;

                var random = new Random();
                var sb = new StringBuilder();
                

                for (int i = 0; i < count; ++i)
                {
                    if (sb.ToString() != "")
                        sb.Append(",");

                    var val = random.Next(min, max + 1);

                    sb.Append(val);
                    sum += val;
                    m_sc.Post(_ => m_labelNumbers.Content = sb.ToString(), null);
                    Thread.Sleep(300);
                }
                
                m_sc.Post(_ => m_buttonOK.IsEnabled = true, null);             
            }
            catch (Exception ex) {
                m_sc.Post(m => m_labelResult.Content = m, ex.Message);
            }

            return sum;            
        }

        private void m_buttonOK_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                var min = int.Parse(m_textBoxMin.Text);
                var max = int.Parse(m_textBoxMax.Text);
                var count = int.Parse(m_textBoxCount.Text);

                var task = new Task<int>(randomGeneratorThreadCallback, );

                task.Start();
                task.ContinueWith(t => m_sc.Post(_ => m_labelResult.Content = t.Result, null));
                
                m_buttonOK.IsEnabled = false;
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid values");
            }
        }

        private void m_buttonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
