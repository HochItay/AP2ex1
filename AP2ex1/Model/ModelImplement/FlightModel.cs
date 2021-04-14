﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;

using PluginInterface;
using System.Windows;

namespace AP2ex1.Model
{

    /// <summary>
    /// this class is an implementation of the general Model in the Flight-Simulator
    /// </summary>
    public partial class FlightModel : IMMain
    {

        public event PropertyChangedEventHandler PropertyChanged;

        // some constants for the class.
        private const int FPS = 10; // default value of FPS - frames per second.
        private const double MILI = 1000.0; // second in milliseconds.
        private readonly string regFlight = Directory.GetCurrentDirectory() + @"\..\..\..\resources\reg_flight.csv";
        
        private int serverPort = 5400;      // the port on which the FlightGear should be run.

        // the flight-simulator specifications.
        private volatile bool isRunning = false;     // when creating a model, it does not run the flight.
        private double speed = 1.0;
        // we start a flight from time 0s.
        private volatile int currentTime = 0;       // current time in flight, in seconds.
        private volatile int currentLine = 0;       // each line represent a single frame.
        private int dataLength;             // number of frames in flight.
        private string flightFilePath;      // path to the flight data.

        // anomaly related fields
        private IAnomalyDetector ad;
        // maps each pair of properties to its anomalies
        private SortedDictionary<Tuple<string,string>, IList<Point>> anomaliesByFeatures;

        // we use FilesParser in order to parse the flight setting and data.
        private FilesParser fp;     

        /// <summary>
        /// the constructor.
        /// initializes the FilesParser.
        /// </summary>
        public FlightModel()
        {
            fp = new FilesParser();

        }

        /// <summary>
        /// Property for current line in the data file.
        /// </summary>
        public int CurrentLine
        {
            get
            {
                return currentLine;
            }

            set
            {
                // check boundaries
                if (value >= fp.DataLength)
                {
                    currentLine = fp.DataLength - 1;
                } else if (value < 0)
                {
                    currentLine = 0;
                } else
                {
                    currentLine = value;
                }

                // also change current time
                currentTime = (int)currentLine / FPS;
                NotifyChanges();           // notifies all the fields have changed - because we passed to a new frame.
                NotifyPropertyChanged(nameof(VideoCurrentTime));
                NotifyPropertyChanged(nameof(CurrentLine));
            }
        }


        /// <summary>
        /// The speed of the flight video.
        /// </summary>
        public double VideoSpeed { 
            get => speed;
            set
            {
                speed = value;
                NotifyPropertyChanged(nameof(VideoSpeed));
            }
        }

        /// <summary>
        /// the length of the video (in seconds), as stored in the data file.
        /// </summary>
        public int VideoLength { 
            get => dataLength / FPS;
        }

        /// <summary>
        /// Property for current time in the flight video.
        /// </summary>
        public int VideoCurrentTime
        {
            get => currentTime;
            set 
            { 
                // also change current line
                CurrentLine = (int)value * FPS;
            }
        }
        
        /// <summary>
        /// whether or not the video is currently running.
        /// </summary>
        public bool VideoIsRunning { 
            get => isRunning;
            set
            {
                if (!isRunning & value)
                {
                    isRunning = true;
                    Thread thread = new Thread(new ThreadStart(run));
                    thread.Start();
                }
                isRunning = value;
                NotifyPropertyChanged(nameof(VideoIsRunning));
            }
        }

        /// <summary>
        /// get all the variables of the flight.
        /// </summary>
        /// <returns> all names of the variables in the XML file. </returns>
        public IList<string> GetVarsNames()
        {
            return fp.GetPropertiesNames();
        }


        public void LoadDeviationAlgorithm(string filePath)
        {
            ad = AnomalyDllLoader.LoadDll(filePath);
            ad.LearnNormal(regFlight, fp.GetPropertiesNames());

            if (flightFilePath != null)
            {
                this.InitAnomalies();
            }
        }

        /// <summary>
        /// return a graph that represent the anomaly algorithm
        /// the graph is represented by a function, starting coordinate and ending coordinate
        /// </summary>
        /// <param name="feature"> feature to get graph of</param>
        /// <returns> we return list of this tuples to be able to draw non-function graphs such as circle</returns>
        public IList<Tuple<Func<double, double>, double, double>> GetGraph(string feature)
        {
            return ad.GetGraph(feature);
        }

        /// <summary>
        /// loading the data file.
        /// </summary>
        /// <param name="filePath"> the path of the data file (csv file). </param>
        public void LoadFlightDataFile(string filePath)
        {
            this.flightFilePath = filePath;
            fp.LoadData(filePath);
            dataLength = fp.DataLength;
            NotifyPropertyChanged(nameof(VideoLength));     // when we load a data file - the video length changes.

            if (ad != null)
            {
                this.InitAnomalies();
            }
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
        /// detect anomalies and initialize anomaliesByFeatures field
        /// </summary>
        private void InitAnomalies()
        {
            IList<Tuple<int, string, string>> allAnomalies = ad.DetectAnomalies(this.flightFilePath);

            anomaliesByFeatures = new SortedDictionary<Tuple<string, string>, IList<Point>>();

            // initialize all lists
            foreach (string feature1 in this.GetVarsNames())
            {
                foreach (string feature2 in this.GetVarsNames())
                {
                    anomaliesByFeatures.Add(Tuple.Create(feature1, feature2), new List<Point>());
                }
            }

            foreach (Tuple<int, string, string> anomaly in allAnomalies)
            {
                Point p1 = new Point(fp.GetPropertyAtLine(anomaly.Item2, anomaly.Item1), fp.GetPropertyAtLine(anomaly.Item3, anomaly.Item1));
                Point p2 = new Point(fp.GetPropertyAtLine(anomaly.Item3, anomaly.Item1), fp.GetPropertyAtLine(anomaly.Item2, anomaly.Item1));
                anomaliesByFeatures[Tuple.Create(anomaly.Item2, anomaly.Item3)].Add(p1);
                anomaliesByFeatures[Tuple.Create(anomaly.Item3, anomaly.Item2)].Add(p2);
            }
        } 

        /// <summary>
        /// starts to run
        /// </summary>
        private void run()
        {

            var server = new Socket(SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect("127.0.0.1", serverPort);
            }
            catch
            {
                ;
            }
            Stopwatch sw = new Stopwatch();
            while (isRunning)
            {
                double sleepTIme = (MILI / FPS) / speed;
                
                sw.Restart();

                if (server.Connected)       // if we are connected to the server - we send it the data.
                {
                    var values = fp.GetLine(currentLine);
                    byte[] msg = System.Text.Encoding.UTF8.GetBytes(string.Join(",", values) + "\n");
                    server.Send(msg);
                }

                // going to the next line in the flight data file.
                CurrentLine = currentLine + 1;

                if (currentLine == dataLength - 1)  // if we finished iterating through the data.
                {
                    VideoIsRunning = false;
                }

                sw.Stop();

                sleepTIme -= sw.ElapsedMilliseconds;
                if (sleepTIme > 0)
                {
                    Thread.Sleep((int)sleepTIme);
                }
            }
            if (server.Connected)
            {
                server.Disconnect(false);
            }
            server.Dispose();
            
        }

        private void NotifyPropertyChanged(string msg)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(msg));
            }
        }

        public int GetNumPointsPerSec()
        {
            return FPS;
        }

        public string GetCorrelativeVar(string var)
        {
            return ad.GetCorrelatedFeature(var);
        }

        public IList<Point> GetVarPoints(string var)
        {
            IList<Point> points = new List<Point>();
            for (int i=0; i < fp.DataLength; i++)
            {
                points.Add(new Point((int)(i / FPS), fp.GetPropertyAtLine(var, i)));
            }

            return points;
        }

        public Tuple<IList<Point>, IList<Point>> GetAnomalyGraphPoints(string var, string corrilativeVar)
        {
            IList<Point> anomaliesPoints = anomaliesByFeatures[Tuple.Create(var, corrilativeVar)];

            IList<Point> allPoints = new List<Point>();
            for (int i = 0; i < fp.DataLength; i++)
            {
                allPoints.Add(new Point(fp.GetPropertyAtLine(var, i), fp.GetPropertyAtLine(corrilativeVar, i)));
            }

            return Tuple.Create(allPoints, anomaliesPoints);
        }

        public IList<Tuple<Func<double, double>, double, double>> GetGraphFuncs(string var)
        {
            return ad.GetGraph(var);
        }
    }

}
