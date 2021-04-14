using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.IControlersModel
{
    public interface IMFlightData
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
        int JoystickX
        {
            get;
        }
        int VM_JoystickY
        {
            get;
        }
    }
}
