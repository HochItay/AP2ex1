using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AP2ex1.Model
{
    public interface IFlightModel : INotifyPropertyChanged
    {
        // video related properties
        float VideoSpeed { get; set; }
        int VideoLength { get; }
        int VideoCurrentTime { get; set; }
        bool VideoIsRunning { get; set; }

        string ChosenProperty { get; set; }
        bool VideoIsRunning { get; set; }
        bool VideoIsRunning { get; set; }

        // file loading methods
        void LoadFlightDataFile(string filePath);
        void LoadSettingsFile(string filePath);
    }
}
