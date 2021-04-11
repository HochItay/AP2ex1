using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.controlersViewModel
{
    interface IVMYPRDisplayer
    {
        int Yaw
        {
            set;
            get;
        }
        int Pitch
        {
            set;
            get;
        }
        int Roll
        {
            set;
            get;
        }
    }
}
