using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.ViewModel
{
    interface IVMYPRDisplayer
    {
        int VM_Yaw
        {
            get;
        }
        int VM_Pitch
        {
            get;
        }
        int VM_Roll
        {
            get;
        }
    }
}
