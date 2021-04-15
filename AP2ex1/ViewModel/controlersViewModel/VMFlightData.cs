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
        private readonly int normalizeJoystick = 100;
        private readonly int centerlizeJoystick = 125;
        private Model.IMFlightData model;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public VMFlightData(Model.IMFlightData model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
             {
                 string varNames = "VM_" + e.PropertyName;
                 if(varNames.Equals("VM_CompassAngle")  || varNames.Equals("VM_Speed") || varNames.Equals("VM_Speed") || 
                 varNames.Equals("VM_Height") || varNames.Equals("VM_JoystickX") || varNames.Equals("VM_JoystickY"))
                 {
                     NotifyPropertyChanged(varNames);
                 }
             };

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
                return model.Speed;
            }
        }
        public int VM_Height
        {
            get
            {
                return model.Height;
            }
        }
        public double VM_JoystickX
        {
            get
            {
                return model.JoystickX * normalizeJoystick + centerlizeJoystick;

            }
        }
        public double VM_JoystickY
        {
            get
            {
                return model.JoystickY * normalizeJoystick + centerlizeJoystick;

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
