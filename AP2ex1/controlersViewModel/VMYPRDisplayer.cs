using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.controlersViewModel
{
    class VMYPRDisplayer : IVMYPRDisplayer
    {
        private int yaw;
        private int pitch;
        private int roll;
        public int VM_Yaw
        {
            get
            {
                return yaw;
            }
            set
            {
                yaw = value;
            }
        }
        public int VM_Pitch
        {
            get
            {
                return pitch;
            }
            set
            {
                pitch = value;
            }
        }
        public int VM_Roll
        {
            get
            {
                return roll;
            }
            set
            {
                roll = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
