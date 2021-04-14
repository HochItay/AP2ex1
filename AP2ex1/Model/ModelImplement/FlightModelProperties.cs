using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PluginInterface;
using System.Windows;

namespace AP2ex1.Model
{
    public partial class FlightModel : IFlightModel
    {
        private readonly string[] properties =  { "CompassAngle", "Speed", "Height", "JoystickX", "JoystickY", "Yaw", "Pitch", "Roll"};

        public int CompassAngle
        {
            get 
            {        
                return (int) fp.GetPropertyAtLine("indicated-heading-deg", currentLine); 
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

        public int VM_JoystickY => throw new NotImplementedException();

        public void FGPathChanged(string path)
        {
            throw new NotImplementedException();
        }

        public void GoBackTen()
        {
            CurrentLine = CurrentLine - 10 * FPS;
        }

        public void GoToEnd()
        {
            CurrentLine = dataLength;
        }

        public void PlayClicked()
        {
            VideoIsRunning = !isRunning;
        }

        public void SkipTen()
        {
            CurrentLine = CurrentLine + 10 * FPS;
        }

        public void StartOver()
        {
            CurrentLine = 0;
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
