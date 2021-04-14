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
        // all the properties of the plane (meaning, those we got from the data file, not those we set such as CurrentLine).
        private readonly string[] properties =  { "CompassAngle", "Speed", "Height", "JoystickX", "JoystickY", "Yaw", "Pitch", "Roll"};

        /// <summary>
        /// the angle the plane is headed toward.
        /// </summary>
        public int CompassAngle
        {
            get 
            {        
                return (int) fp.GetPropertyAtLine("indicated-heading-deg", currentLine); 
            }
        }

        /// <summary>
        /// the speed of the plane, in kt.
        /// </summary>
        public int Speed
        {
            get
            {
                return (int)fp.GetPropertyAtLine("airspeed-kt", currentLine);
            }
        }


        /// <summary>
        /// the height of the plane, in ft.
        /// </summary>
        public int Height
        {
            get
            {
                return (int)fp.GetPropertyAtLine("altitude-ft", currentLine);
            }
        }

        /// <summary>
        /// the position of the Yoke in the x-axis.
        /// </summary>
        public int JoystickX
        {
            get
            {
                return (int)fp.GetPropertyAtLine("aileron", currentLine);
            }
        }

        /// <summary>
        /// the position of the Yoke in the y-axis.
        /// </summary>
        public int JoystickY
        {
            get
            {
                return (int)fp.GetPropertyAtLine("elevator", currentLine);
            }
        }

        /// <summary>
        /// the Yaw angle of the plane.
        /// </summary>
        public int Yaw
        {
            get
            {
                return (int)fp.GetPropertyAtLine("side-slip-deg", currentLine);
            }
        }

        /// <summary>
        /// the Pitch angle of the plane.
        /// </summary>
        public int Pitch
        {
            get
            {
                return (int)fp.GetPropertyAtLine("pitch-deg", currentLine);
            }
        }


        /// <summary>
        /// the Roll angle of the plane.
        /// </summary>
        public int Roll
        {
            get
            {
                return (int)fp.GetPropertyAtLine("roll-deg", currentLine);
            }
        }


        /// <summary>
        /// this method starts the FlightGear application, and should only be run once.
        /// </summary>
        /// <param name="path"> the path to the exe file in the FlightGear bin folder. </param>
        public void FGPathChanged(string path)
        {
            try   // because this command may fail.
            {
                string directoryPath = Path.GetDirectoryName(path);
                string xml = "playback_small";      // note - this file must be in the Protocol directory.
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
            }
            catch
            {
                ;
            }
        }


        /// <summary>
        /// returns 10 seconds back in the video.
        /// </summary>
        public void GoBackTen()
        {
            CurrentLine = CurrentLine - 10 * FPS;
        }
        
        /// <summary>
        /// goes 10 seconds forward.
        /// </summary>
        public void SkipTen()
        {
            CurrentLine = CurrentLine + 10 * FPS;
        }


        /// <summary>
        /// goes to the end of the video.
        /// </summary>
        public void GoToEnd()
        {
            CurrentLine = dataLength;
        }

        /// <summary>
        /// goes to the start of the video.
        /// </summary>
        public void StartOver()
        {
            CurrentLine = 0;
        }

        /// <summary>
        /// stops the video if playing, or staring it if not.
        /// </summary>
        public void PlayClicked()
        {
            VideoIsRunning = !isRunning;
        }


        
        
        /// <summary>
        /// notifies all the properties in the `properties` list have changed.
        /// used to update all changes due to change at time.
        /// </summary>
        private void NotifyChanges()
        {
            foreach (string prop in properties)
            {
                NotifyPropertyChanged(prop);
            }
        }
    }
}
