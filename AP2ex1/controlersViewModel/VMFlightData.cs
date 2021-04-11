using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.controlersViewModel
{
    class VMFlightData : IVMFlightData
    {
        private int compassAngle = 180;
        public int CompassAngle
        {
            get
            {
                return compassAngle;
            }
            set
            {
                compassAngle = value;
            }
        }
    }
}
