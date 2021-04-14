using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.ViewModel
{
    public interface IVMFlightControllers : INotifyPropertyChanged
    {
        public double VM_Throttle
        {
            get;
        }
        public double VM_Aileron
        {
            get;
        }
        public double VM_Elevator
        {
            get;
        }
        public double VM_Rudder
        {
            get;
        }
    }
}
