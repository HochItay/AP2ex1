using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using AP2ex1.Model;

namespace AP2ex1.ViewModel
{
    // implementation of IFlightViewModel
    public class FlightViewModel : IFlightViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IFlightModel model;

        public FlightViewModel(IFlightModel model)
        {
            this.model = model;
        }

        public float VideoSpeed
        {
            get { return model.VideoSpeed; }
            set { model.VideoSpeed = value; }
        }

        public int VideoLength
        {
            get { return model.VideoLength; }
        }

        public int VideoCurrentTime
        {
            get { return model.VideoCurrentTime; }
            set { model.VideoCurrentTime = value; }
        }

        public bool VideoIsRunning
        {
            get { return model.VideoIsRunning; }
            set { model.VideoIsRunning = value; }
        }

        public string ChosenProperty
        {
            get { return model.ChosenProperty; }
            set { model.ChosenProperty = value; }
        }

        public string CorrelativeProperty
        {
            get { return model.CorrelativeProperty; }
        }

        public void LoadFlightDataFile(string filePath)
        {
            model.LoadFlightDataFile(filePath);
        }

        public void LoadSettingsFile(string filePath)
        {
            model.LoadSettingsFile(filePath);
        }

        public void LoadAnomalyAlgorithm(string filePath)
        {
            model.LoadAnomalyAlgorithm(filePath);
        }



    }
}
