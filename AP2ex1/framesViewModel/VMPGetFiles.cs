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

        private string fGPath;
        public string FGPath
        {
            get
            {
                return fGPath;
            }

            set
            {
                if(fGPath != value)
                {
                    fGPath = value;
                    getFilesM.FGPathChanged(fGPath);
                }
            }
        }

        public VMPGetFiles(framesIModel.IMPGetFiles getFilesM)
        {
            this.getFilesM = getFilesM;
        }

        public void FileDataChanged(string filePath)
        {
            if (filePath.Equals(constatnts.Paths.CSV_FILE_PATH)) {
                getFilesM.LoadFlightDataFile(fGPath);
            } else if(filePath.Equals(constatnts.Paths.XML_FILE_PATH))
            {
                getFilesM.LoadSettingsFile(fGPath);
            } else if (filePath.Equals(constatnts.Paths.DLL_FILE_PATH))
            {
                getFilesM.LoadDeviationAlgorithm(fGPath);
            }
        }
    }
}
