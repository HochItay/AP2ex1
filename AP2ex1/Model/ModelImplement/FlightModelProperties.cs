using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using PluginInterface;
using System.Windows;

namespace AP2ex1.Model
{
    public partial class FlightModel : IMMain
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

        /// <summary>
        /// this method starts the FlightGear application, and should only be run once.
        /// </summary>
        /// <param name="path"> the path to the exe file in the FlightGear bin folder. </param>
        public void FGPathChanged(string path)
        {
            string directoryPath = Path.GetDirectoryName(path);
            string xml = "playback_small";
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.WorkingDirectory = directoryPath;
            cmd.Start();
            cmd.StandardInput.WriteLine("fgfs --generic=socket,in,10,127.0.0.1,5400,tcp,{0} --fdm=null", xml);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
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
