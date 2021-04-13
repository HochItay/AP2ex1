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
        private int joystickX;
        private int joystickY;
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
        public int VM_JoystickX
        {
            get
            {
                return joystickX;

            }
            set
            {
                joystickX = 90 + (int)(0.7 * value);
            }
        }
        public int VM_JoystickY
        {
            get
            {
                return joystickY;

            }
            set
            {
                joystickY = 90 + (int)(0.7 * value);
            }
        }
    }
}
