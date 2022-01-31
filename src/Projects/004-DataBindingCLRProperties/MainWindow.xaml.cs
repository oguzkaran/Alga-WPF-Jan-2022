using DataBindingCLRProperties.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DataBindingCLRProperties
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SensorViewModel m_sensorViewModel;


        private void clearSensorViewModel()
        {
            m_sensorViewModel.Name = "";
            m_sensorViewModel.Host = "127.0.0.1";
            m_sensorViewModel.Port = 1024;
        }

        public MainWindow()
        {
            InitializeComponent();
            m_sensorViewModel = new SensorViewModel { Name = "", Host = "127.0.0.1", Port = 1024 };
            DataContext = m_sensorViewModel;
        }

        private void onSaveButtonClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show(m_sensorViewModel.ToString(), "Sensor Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (FormatException) {
                MessageBox.Show("Invalid Port Value", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void onClearButtonClicked(object sender, RoutedEventArgs e)
        {
            clearSensorViewModel();
        }
    }
}
