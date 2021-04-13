using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        }
        public int VM_Speed
        {
            get
            {
                return speed;
            }
        }
        public int VM_Height
        {
            get
            {
                return height;
            }
        }
        public int VM_JoystickX
        {
            get
            {
                return joystickX;

            }
        }
        public int VM_JoystickY
        {
            get
            {
                return joystickY;

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
