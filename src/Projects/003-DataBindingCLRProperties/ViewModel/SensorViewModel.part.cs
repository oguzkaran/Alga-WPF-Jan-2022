using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingCLRProperties.ViewModel
{
    public partial class SensorViewModel
    {
        public override string ToString() => $"[{Name}]{Host}:{Port}";        
    }
}
