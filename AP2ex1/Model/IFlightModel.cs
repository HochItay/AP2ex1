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
        double VideoSpeed { get; set; }
        int VideoLength { get; }
        int VideoCurrentTime { get; set; }
        bool VideoIsRunning { get; set; }
        
        string ChosenProperty { get; set; }
        string CorrelativeProperty { get; }
        
        // gets all the names of the variables.
        IList<string> GetVarsNames();

        // file loading methods
        void LoadFlightDataFile(string filePath);
        void LoadSettingsFile(string filePath);
        void LoadDeviationAlgorithm(string filePath);
    }
}
