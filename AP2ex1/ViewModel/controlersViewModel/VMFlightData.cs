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
                 string var = "VM_" + e.PropertyName;
                 if(var.Equals("VM_CompassAngle")  || var.Equals("VM_Speed") || var.Equals("VM_Speed") || 
                 var.Equals("VM_Height") || var.Equals("VM_JoystickX") || var.Equals("VM_JoystickY"))
                 {
                     NotifyPropertyChanged("VM_" + e.PropertyName);
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
                return model.JoystickY;

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
