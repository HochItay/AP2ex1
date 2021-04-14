using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.Model
{
    public interface IMPGetFiles
    {
        void FGPathChanged(string path);
        void LoadFlightDataFile(string path);
        void LoadSettingsFile(string path);
        void LoadDeviationAlgorithm(string path);
    }
}
