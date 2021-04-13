using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.Model
{
    public partial class FlightModel : IFlightModel
    {
        private readonly string[] properties =  { "CompassAngle", "Speed", "Height", "JoystickX", "JoystickY", "Yaw", "Pitch", "Roll"};

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
                return (int)fp.GetPropertyAtLine("", currentLine);
            }
        }

        public int Height
        {
            get
            {
                return (int)fp.GetPropertyAtLine("", currentLine);
            }
        }

        public int JoystickX
        {
            get
            {
                return (int)fp.GetPropertyAtLine("", currentLine);
            }
        }

        public int JoystickY
        {
            get
            {
                return (int)fp.GetPropertyAtLine("", currentLine);
            }
        }

        public int Yaw
        {
            get
            {
                return (int)fp.GetPropertyAtLine("", currentLine);
            }
        }

        public int Pitch
        {
            get
            {
                return (int)fp.GetPropertyAtLine("", currentLine);
            }
        }

        public int Roll
        {
            get
            {
                return (int)fp.GetPropertyAtLine("", currentLine);
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
