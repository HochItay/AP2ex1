using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.controlersViewModel
{
    interface IVMYPRDisplayer
    {
        int VM_Yaw
        {
            set;
            get;
        }
        int VM_Pitch
        {
            set;
            get;
        }
        int VM_Roll
        {
            set;
            get;
        }
    }
}
