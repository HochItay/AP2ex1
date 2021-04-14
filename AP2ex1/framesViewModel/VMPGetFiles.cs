using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.framesViewModel
{
    class VMPGetFiles : IVMPGetFiles
    {
        private framesIModel.IMPGetFiles getFilesM;

        public VMPGetFiles(framesIModel.IMPGetFiles getFilesM)
        {
            this.getFilesM = getFilesM;
        }

        public void FileDataChanged(string filePath)
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
    }
}
