using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.ViewModel
{
    class VMMain : IVMMain
    {
        private IVMPGetFiles vmPGetFiles;
        private IVMPSimulator vmPSimulator;
        /// <summary>
        /// init the vm main with a model.
        /// the vm communicates with his model by MVVM arcitecture.
        /// </summary>
        /// <param name="model"></param>
        public VMMain(Model.IMMain model)
        {
            vmPGetFiles = new VMPGetFiles(model);
            vmPSimulator = new VMPSimulator(model);
        }
        public IVMPGetFiles GetVMPGetFiles()
        {
            return vmPGetFiles;
        }

        public IVMPSimulator GetVMPSimulator()
        {
            return vmPSimulator;
        }
    }
}
