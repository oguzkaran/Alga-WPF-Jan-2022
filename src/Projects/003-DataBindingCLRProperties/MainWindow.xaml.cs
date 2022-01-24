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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void onSaveButtonClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var sensorViewModel = new SensorViewModel { Name = m_textBoxSensorName.Text, Host = m_textBoxSensorHost.Text, Port = int.Parse(m_textBoxSensorPort.Text) };

                MessageBox.Show(sensorViewModel.ToString(), "Sensor Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (FormatException) {
                MessageBox.Show("Invalid Port Value", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void onClearButtonClicked(object sender, RoutedEventArgs e)
        {
            m_textBoxSensorName.Text = "";
            m_textBoxSensorHost.Text = "";
            m_textBoxSensorPort.Text = "";
        }
    }
}
