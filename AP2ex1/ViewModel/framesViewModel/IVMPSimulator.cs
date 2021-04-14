using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.ViewModel
{
    public interface IVMPSimulator
    {
        IVMFlightData GetVMFlightData();
        IVMMediaController GetVMMediaController();
        IVMYPRDisplayer GetVMYPRDisplayer();
        VMGraphController GetVMGraphController();
    }
}
