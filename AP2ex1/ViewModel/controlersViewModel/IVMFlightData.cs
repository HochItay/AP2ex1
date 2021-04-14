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
        int VM_JoystickX
        {
            get;
        }
        int VM_JoystickY
        {
            get;
        }
    }
}
