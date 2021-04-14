using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.Model
{
    public interface IMFlightData : INotifyPropertyChanged
    {
        int CompassAngle
        {
            get;
        }
        int Speed
        {
            get;
        }
        int Height
        {
            get;
        }
        double JoystickX
        {
            get;
        }
        double JoystickY
        {
            get;
        }
    }
}
