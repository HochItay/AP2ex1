using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.controlersViewModel
{
    class VMMediaController : IVMMediaController
    {
        private double speed = 1;
        public double VMSpeed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = Math.Round(value, 1);
            }
        }
    }
}
