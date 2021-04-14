using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.ViewModel
{
    class VMYPRDisplayer : IVMYPRDisplayer
    {
        Model.IMYPRDisplayer model;
        public VMYPRDisplayer(Model.IMYPRDisplayer model)
        {
            this.model = model;
        }
        public int VM_Yaw
        {
            get
            {
                return model.Yaw;
            }
        }
        public int VM_Pitch
        {
            get
            {
                return model.Pitch;
            }
        }
        public int VM_Roll
        {
            get
            {
                return model.Roll;
            }
        }

    }
}
