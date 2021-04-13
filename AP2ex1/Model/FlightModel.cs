using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace AP2ex1.Model
{
    class FlightModel : IFlightModel
    {
        private const int FPS = 10; // default value of FPS.
        private const float MILI = 1000.0; // second in milliseconds.
        
        public event PropertyChangedEventHandler PropertyChanged;

        private Socket server;
        private int serverPort = 5040;
        private volatile bool isRunning = false;     // when creating a model, it does not run the flight.
        private volatile float speed;
        private volatile int currentTime;
        private volatile int currentLine;

        private FilesParser fp;
        
        public FlightModel()
        {
            server = new Socket(SocketType.Stream, ProtocolType.Tcp);
            server.Connect("127.0.0.1", serverPort);
            fp = new FilesParser();
            currentTime = 0;
            
        }

        /// <summary>
        /// The speed of the flight video.
        /// </summary>
        public float VideoSpeed { 
            get => speed;
            set => speed = value; 
        }

        /// <summary>
        /// the length of the video (in seconds), as stored in the data file.
        /// </summary>
        public int VideoLength { get => fp.DataLength / FPS; }

        public int VideoCurrentTime
        {
            get => currentTime;
            set
            {
                currentTime = value;
                currentLine = FPS * currentTime;
            }
        }
        
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

        public IList<string> GetVarsNames()
        {
            return fp.GetPropertiesNames();
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

        /// <summary>
        /// starts to run
        /// </summary>
        private void run()
        {
            Stopwatch sw = new Stopwatch();
            while (isRunning)
            {
                float sleepTIme = (MILI / FPS) / speed;
                sw.Start();
                
                var values = fp.GetLine(currentLine);
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(string.Join(",", values));
                server.Send(msg);
                SendNotification("time_passed");

                // going to the next line in the flight data file.
                currentLine++;
                currentTime = currentLine / FPS;

                sw.Stop();

                sleepTIme -= sw.ElapsedMilliseconds;
                if (sleepTIme > 0)
                {
                    Thread.Sleep((int)sleepTIme);
                }
            }
        }

        private void SendNotification(string msg)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(msg));
            }
        }


    }

}
