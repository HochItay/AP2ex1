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
        
        public event PropertyChangedEventHandler PropertyChanged;

        private Socket s;
        private bool isRunning;
        private int lineNum;
        
        public FlightModel()
        {
            s = new Socket(SocketType.Stream, ProtocolType.Tcp);
        }

        public float VideoSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int VideoLength => throw new NotImplementedException();

        public int VideoCurrentTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool VideoIsRunning { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ChosenProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string CorrelativeProperty => throw new NotImplementedException();


        public void LoadAnomalyAlgorithm(string filePath)
        {
            throw new NotImplementedException();
        }

        public void LoadFlightDataFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public void LoadSettingsFile(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
