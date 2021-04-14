using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.ViewModel
{
    class VMPSimulator : IVMPSimulator
    {
        private IVMFlightData vmFlightData;
        private VMGraphController vmGraphController;
        private IVMMediaController vmMediaController;
        private IVMYPRDisplayer vmYPRDisplayer;

        public VMPSimulator(Model.IMPSimulator model)
        {
            vmFlightData = new VMFlightData(model);
            vmGraphController = new VMGraphController(model);
            vmMediaController = new VMMediaController(model);
            vmYPRDisplayer = new VMYPRDisplayer(model);
        }

        public IVMFlightData GetVMFlightData()
        {
            return vmFlightData;
        }

        public VMGraphController GetVMGraphController()
        {
            return vmGraphController;
        }

        public IVMMediaController GetVMMediaController()
        {
            return vmMediaController;
        }

        public IVMYPRDisplayer GetVMYPRDisplayer()
        {
            return vmYPRDisplayer;
        }
    }
}
