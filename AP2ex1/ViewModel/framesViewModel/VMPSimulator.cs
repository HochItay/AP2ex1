using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.ViewModel
{
    /// <summary>
    /// the view model simulator page part.
    /// </summary>
    class VMPSimulator : IVMPSimulator
    {
        private IVMFlightData vmFlightData;
        private VMGraphController vmGraphController;
        private IVMMediaController vmMediaController;
        private IVMYPRDisplayer vmYPRDisplayer;
        private IVMFlightControllers vmFlightControllers;

        /// <summary>
        /// the constructor of theis class
        /// </summary>
        /// <param name="model">the model to get data from</param>
        public VMPSimulator(Model.IMPSimulator model)
        {
            //creates the sub vm's
            vmFlightData = new VMFlightData(model);
            vmGraphController = new VMGraphController(model);
            vmMediaController = new VMMediaController(model);
            vmYPRDisplayer = new VMYPRDisplayer(model);
            vmFlightControllers = new VMFlightControllers(model);
        }

        public IVMFlightData GetVMFlightData()
        {
            return vmFlightData;
        }

        public VMGraphController GetVMGraphController()
        {
            return vmGraphController;
        }
        public IVMFlightControllers GetVMFlightControllers()
        {
            return vmFlightControllers;
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
