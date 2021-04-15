using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.Model
{
    /// <summary>
    /// this interface is for the flight data model.
    /// </summary>
    public interface IMFlightData : INotifyPropertyChanged
    {
        /// <summary>
        /// the angle of the compass.
        /// </summary>
        int CompassAngle
        {
            get;
        }

        /// <summary>
        /// the speed's value.
        /// </summary>
        int Speed
        {
            get;
        }

        /// <summary>
        /// the hight of the plane.
        /// </summary>
        int Height
        {
            get;
        }

        /// <summary>
        /// the x location value of the joystick.
        /// </summary>
        double JoystickX
        {
            get;
        }

        /// <summary>
        /// the y location value of the joystick.
        /// </summary>
        double JoystickY
        {
            get;
        }
    }
}
