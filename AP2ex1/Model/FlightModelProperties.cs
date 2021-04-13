using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.Model
{
    public partial class FlightModel : IFlightModel
    {
        private readonly string[] properties =  { "CurrentLine","CompassAngle", "Speed", "Height", "JoystickX", "JoystickY", "Yaw", "Pitch", "Roll"};

        public int CompassAngle
        {
            get 
            {        
                return (int) fp.GetPropertyAtLine("", currentLine); 
            }
        }

        public int Speed
        {
            get
            {
                return (int)fp.GetPropertyAtLine("airspeed-kt", currentLine);
            }
        }

        public int Height
        {
            get
            {
                return (int)fp.GetPropertyAtLine("altitude-ft", currentLine);
            }
        }

        public int JoystickX
        {
            get
            {
                return (int)fp.GetPropertyAtLine("aileron", currentLine);
            }
        }

        public int JoystickY
        {
            get
            {
                return (int)fp.GetPropertyAtLine("elevator", currentLine);
            }
        }

        public int Yaw
        {
            get
            {
                return (int)fp.GetPropertyAtLine("side-slip-deg", currentLine);
            }
        }

        public int Pitch
        {
            get
            {
                return (int)fp.GetPropertyAtLine("pitch-deg", currentLine);
            }
        }

        public int Roll
        {
            get
            {
                return (int)fp.GetPropertyAtLine("roll-deg", currentLine);
            }
        }

        public int CurrentLine
        {
            get
            {
                return currentLine;
            }
        }


        private void NotifyChanges()
        {
            foreach (string prop in properties)
            {
                NotifyPropertyChanged(prop);
            }
        }
    }
}
