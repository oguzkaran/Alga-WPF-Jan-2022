using CSD.SensorApp.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace SensorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SensorAppService m_sensorAppService;

        public MainWindow(SensorAppService sensorAppService)
        {
            InitializeComponent();
            m_sensorAppService = sensorAppService;

            //doWork();
        }

        public MainWindow() //?
        {
            InitializeComponent();
            Close();
        }

        private async void doWork()
        {
            var sensors = await m_sensorAppService.FindSensorsByNameAsync("abc");

            Dispatcher.Invoke((Action)(() => MessageBox.Show(sensors.Count().ToString())));
        }
    }
}
