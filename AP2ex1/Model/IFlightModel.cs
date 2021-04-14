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
<<<<<<< HEAD
        double VideoSpeed { get; set; }
        int VideoLength { get; }
        int VideoCurrentTime { get; set; }
        bool VideoIsRunning { get; set; }
        
        string ChosenProperty { get; set; }
        string CorrelativeProperty { get; }
        
        // gets all the names of the variables.
        IList<string> GetVarsNames();
=======
        float VideoSpeed { get; set; }
        int VideoLength { get; }
        int VideoCurrentTime { get; set; }
        bool VideoIsRunning { get; set; }

        string ChosenProperty { get; set; }
<<<<<<< HEAD
        bool VideoIsRunning { get; set; }
        bool VideoIsRunning { get; set; }
>>>>>>> bea47d6 (first implementaion of IFlightModel, IFlightViewModel and FlightViewModel)
=======
        string CorrelativeProperty { get; }
>>>>>>> 330fc0c (reorgenize the files)

        // file loading methods
        void LoadFlightDataFile(string filePath);
        void LoadSettingsFile(string filePath);
<<<<<<< HEAD
<<<<<<< HEAD
        void LoadDeviationAlgorithm(string filePath);
=======
>>>>>>> bea47d6 (first implementaion of IFlightModel, IFlightViewModel and FlightViewModel)
=======
        void LoadAnomalyAlgorithm(string filePath);
>>>>>>> 330fc0c (reorgenize the files)
    }
}
