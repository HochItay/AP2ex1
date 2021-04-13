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
        private int speed = 150;
        private int height = 100;
        public int VM_CompassAngle
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
        public int VM_Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }
        public int VM_Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
    }
}
