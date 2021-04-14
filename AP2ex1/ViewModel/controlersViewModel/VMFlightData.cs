using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.ViewModel
{
    class VMFlightData : IVMFlightData
    {
        private Model.IMFlightData model;
        public VMFlightData(Model.IMFlightData model)
        {
            this.model = model;
        }
        public int VM_CompassAngle
        {
            get
            {
                return model.CompassAngle;
            }

        }
        public int VM_Speed
        {
            get
            {
                return model.CompassAngle;
            }
        }
        public int VM_Height
        {
            get
            {
                return model.Height;
            }
        }
        public int VM_JoystickX
        {
            get
            {
                return model.JoystickX;

            }
        }
        public int VM_JoystickY
        {
            get
            {
                return model.VM_JoystickY;

            }
        }

    }
}
