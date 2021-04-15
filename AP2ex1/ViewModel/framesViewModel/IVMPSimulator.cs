using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.ViewModel
{
    public interface IVMPSimulator
    {
        /// <summary>
        /// return the VMFlightData.
        /// </summary>
        /// <returns></returns>
        IVMFlightData GetVMFlightData();
        /// <summary>
        /// return VMMediaController
        /// </summary>
        /// <returns></returns>
        IVMMediaController GetVMMediaController();
        /// <summary>
        /// return the VMYPRDisplayer.
        /// </summary>
        /// <returns></returns>
        IVMYPRDisplayer GetVMYPRDisplayer();
        /// <summary>
        /// return the VMGraphController
        /// </summary>
        /// <returns>VMGraphController</returns>
        VMGraphController GetVMGraphController();
        /// <summary>
        /// return the VMFlightControllers
        /// </summary>
        /// <returns>IVMFlightControllers</returns>
        IVMFlightControllers GetVMFlightControllers();
    }
}
