using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AP2ex1.Model
{
    public interface IFlightModel : IMFlightData, IMGraphController, IMMediaController, IMYPRDisplayer, IMPGetFiles
    {
    }
}
