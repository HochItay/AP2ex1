using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.Model
{
    /// <summary>
    /// this interface is for the getfiles page.
    /// </summary>
    public interface IMPGetFiles
    {
        /// <summary>
        /// Loading the flight geer from the new path.
        /// </summary>
        /// <param name="path">the new path to load from</param>
        void FGPathChanged(string path);

        /// <summary>
        /// Loading the csv file (that contians the flight data) from the new path.
        /// </summary>
        /// <param name="path">the new path to load from</param>
        void LoadFlightDataFile(string path);

        /// <summary>
        /// Loading the .xml file (that contains the names of the flight vars) from the new path.
        /// </summary>
        /// <param name="path">the new path to load from</param>
        void LoadSettingsFile(string path);

        /// <summary>
        /// Loading the dll (the anomaly algorithem) from the new path.
        /// </summary>
        /// <param name="path">the new path to load from</param>
        void LoadDeviationAlgorithm(string path);
    }
}
