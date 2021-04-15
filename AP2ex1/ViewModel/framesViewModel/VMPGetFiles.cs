using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AP2ex1.ViewModel
{
    class VMPGetFiles : IVMPGetFiles
    {
        private Model.IMPGetFiles getFilesM;

        public VMPGetFiles(Model.IMPGetFiles getFilesM)
        {
            this.getFilesM = getFilesM;
        }

        public void FileDataChanged(string filePath)
        {
            try
            {
                if (filePath.EndsWith(".exe"))
                {
                    getFilesM.FGPathChanged(filePath);
                }
                else if (filePath.EndsWith(".dll"))
                {
                    getFilesM.LoadDeviationAlgorithm(filePath);
                }
                else if (filePath.EndsWith(".csv"))
                {
                    getFilesM.LoadFlightDataFile(filePath);
                }
                else if (filePath.EndsWith(".xml"))
                {
                    getFilesM.LoadSettingsFile(filePath);
                }
            }
            catch
            {
                MessageBox.Show("Error in loading file please try again", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
