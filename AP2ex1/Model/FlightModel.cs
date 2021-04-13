using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.ComponentModel;

namespace AP2ex1.Model
{
    class FlightModel : IFlightModel
    {
        private int FPS = 10; // default value of FPS.

        public event PropertyChangedEventHandler PropertyChanged;

        private Socket s;
        private bool isRunning = false;     // when creating a model, it does not run.
        private int lineNum;
        private float speed;

        private FilesParser fp;
        
        public FlightModel()
        {
            s = new Socket(SocketType.Stream, ProtocolType.Tcp);
            fp = new FilesParser();
        }

        public float VideoSpeed { 
            get => throw new NotImplementedException();
            set => throw new NotImplementedException(); 
        }

        /// <summary>
        /// the length of the video (in seconds), as stored in the data file.
        /// </summary>
        public int VideoLength { get => fp.DataLength / FPS; }

        public int VideoCurrentTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        /// <summary>
        /// whether or not the video is currently running.
        /// </summary>
        public bool VideoIsRunning { 
            get => isRunning;
            set
            {
                isRunning = value;
                if (value)
                {
                    /// some logic here - run the flight.
                }
            }
        }
        public string ChosenProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string CorrelativeProperty => throw new NotImplementedException();


        public void LoadAnomalyAlgorithm(string filePath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// loading the data file.
        /// </summary>
        /// <param name="filePath"> the path of the data file (csv file). </param>
        public void LoadFlightDataFile(string filePath)
        {
            fp.LoadData(filePath);
        }

        /// <summary>
        /// load the settings file.
        /// </summary>
        /// <param name="filePath"> the path to the settings file (XML file). </param>
        public void LoadSettingsFile(string filePath)
        {
            fp.LoadSettings(filePath);
        }
    }
}
