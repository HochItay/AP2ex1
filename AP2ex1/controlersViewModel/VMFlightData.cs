﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.controlersViewModel
{
    class VMFlightData : IVMFlightData
    {
        private IControlersModel.IMFlightData model;
        public VMFlightData(IControlersModel.IMFlightData model)
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
