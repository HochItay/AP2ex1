using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.controlersViewModel
{
    interface IVMFlightData
    {
        int VM_CompassAngle
        {
            set;
            get;
        }
        int VM_Speed
        {
            set;
            get;
        }
        int VM_Height
        {
            set;
            get;
        }
    }
}
