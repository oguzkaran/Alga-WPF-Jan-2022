using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private BackgroundWorker m_worker;
        private readonly Random m_r = new();        

        public MainWindow()
        {
            InitializeComponent();            
            m_progressBarStatus.Foreground = new SolidColorBrush(Color.FromRgb((byte)m_r.Next(0, 256), (byte)m_r.Next(0, 256), (byte)m_r.Next(0, 256)));
        }

        private void doWorkProc(object sender, DoWorkEventArgs e)
        {
            try
            {
                var param = (Tuple<int, int, int>)e.Argument;

                var min = param.Item1;
                var max = param.Item2;
                var count = param.Item3;

                var random = new Random();
                var sb = new StringBuilder();
                var sum = 0;

                for (int i = 0; i < count && !m_worker.CancellationPending; ++i)
                {
                    if (sb.ToString() != "")
                        sb.Append(",");

                    var val = random.Next(min, max + 1);

                    sb.Append(val);
                    sum += val;
                    m_worker.ReportProgress(100 * (i + 1) / count, sb.ToString());
                    Thread.Sleep(300);
                }

                if (m_worker.CancellationPending)
                    e.Cancel = true;
                e.Result = new Tuple<bool, string>(true, sum.ToString());
            }
            catch (Exception ex) {
                m_worker.ReportProgress(1, ex.Message);
                e.Result = new Tuple<bool, string>(false, ex.Message);
            }
            
        }

        private void progressPercentageSuccessProc(object userState, int progressPercentage)
        {
            m_labelNumbers.Content = userState;
            var brush = new SolidColorBrush(Color.FromRgb((byte)m_r.Next(0, 256), (byte)m_r.Next(0, 256), (byte)m_r.Next(0, 256)));

            m_progressBarStatus.Foreground = brush;
            m_progressBarStatus.Value = progressPercentage;
        }

        private void progressChangedProc(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage) {                
                case 1:
                    m_labelResult.Content = e.UserState.ToString();
                    break;
                default:
                    progressPercentageSuccessProc(e.UserState, e.ProgressPercentage);
                    break;
            }
        }

        private void runWorkerCompletedProc(object sender, RunWorkerCompletedEventArgs e)
        {
            m_buttonOK.IsEnabled = true;
            if (e.Cancelled) {
                m_labelResult.Content = "Operation cancelled";
                return;
            }

            var data = (Tuple<bool, string>)e.Result;

            if (data.Item1)
                m_labelResult.Content = data.Item2;
        }        

        private void m_buttonOK_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                var min = int.Parse(m_textBoxMin.Text);
                var max = int.Parse(m_textBoxMax.Text);
                var count = int.Parse(m_textBoxCount.Text);
                m_worker = new();

                m_worker.DoWork += doWorkProc;
                m_worker.ProgressChanged += progressChangedProc;
                m_worker.WorkerReportsProgress = true;
                m_worker.RunWorkerCompleted += runWorkerCompletedProc;
                m_worker.WorkerSupportsCancellation = true;
                m_worker.RunWorkerAsync(new Tuple<int, int, int>(min, max, count));
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

        private void m_buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                m_worker.CancelAsync();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
