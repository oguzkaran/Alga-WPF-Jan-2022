using SampleValidation.ViewModels;
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

namespace SampleValidation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LoginWindowViewModel m_loginWindowViewModel; //DI ile eklenmeli

        public MainWindow()
        {
            InitializeComponent();
            DataContext = m_loginWindowViewModel = new LoginWindowViewModel(new Services.SampleAppService());
        }

        private void m_buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (m_loginWindowViewModel.CheckAuthorization())
                Close();
        }
    }
}
