using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AP2ex1.ViewModel
{
    /// <summary>
    /// the view model of the get files page.
    /// </summary>
    class VMPGetFiles : IVMPGetFiles
    {
        private Model.IMPGetFiles getFilesM;

        /// <summary>
        /// the constructor of this class
        /// </summary>
        /// <param name="getFilesM">the model to get data from</param>
        public VMPGetFiles(Model.IMPGetFiles getFilesM)
        {
            this.getFilesM = getFilesM;
        }

        public void FileDataChanged(string filePath)
        {
            try
            {
                if (filePath.EndsWith(".exe") )//the flight geer .exe file
                {
                    getFilesM.FGPathChanged(filePath);
                }
                else if (filePath.EndsWith(".dll"))//the algorithem .dll file
                {
                    getFilesM.LoadDeviationAlgorithm(filePath);
                }
                else if (filePath.EndsWith(".csv"))//the flight data .csv file
                {
                    getFilesM.LoadFlightDataFile(filePath);
                }
                else if (filePath.EndsWith(".xml"))//the seeting .xml file
                {
                    getFilesM.LoadSettingsFile(filePath);
                }
            }
            catch
            {
                //if got exepion from loading the files notifies the user
                MessageBox.Show("Error in loading file please try again", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
