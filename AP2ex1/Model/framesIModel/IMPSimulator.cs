using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.Model
{
    /// <summary>
    /// this interface is an extention of all the vm interfaces in the simulator page.
    /// </summary>
    public interface IMPSimulator : IMYPRDisplayer, IMGraphController, IMMediaController, IMFlightData, IMFlightControllers
    {
    }
}
