using CSD.Util.Databinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingCLRProperties.ViewModel
{
    public partial class SensorViewModel : ObservableObject
    {
        private string m_name;

        public string Name
        { 
            get => m_name;

            set {
                if (m_name == value)
                    return;

                m_name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Host{ get; set; }

        public int Port { get; set; }
    }
}
