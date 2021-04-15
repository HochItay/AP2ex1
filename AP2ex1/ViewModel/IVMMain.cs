using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.ViewModel
{
    /// <summary>
    /// this interface is for tha main page vm.
    /// it can return the smaler vm's of the pages.
    /// </summary>
    public interface IVMMain
    {
        /// <summary>
        ///return the vm of the simulation page.
        /// </summary>
        /// <returns> vm</returns>
        IVMPSimulator GetVMPSimulator();
        /// <summary>
        /// return the vm of the get files page.
        /// </summary>
        /// <returns>vm </returns>
        IVMPGetFiles GetVMPGetFiles();
    }
}
