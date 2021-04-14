using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.ViewModel
{
    public interface IVMFlightData : INotifyPropertyChanged
    {
        int VM_CompassAngle
        {
            get;
        }
        int VM_Speed
        {
            get;
        }
        int VM_Height
        {
            get;
        }
        double VM_JoystickX
        {
            get;
        }
        double VM_JoystickY
        {
            get;
        }
    }
}
