using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.ViewModel
{
    class VMFlightControllers : IVMFlightControllers
    {
        private Model.IMFlightControllers model;

        public VMFlightControllers(Model.IMFlightControllers model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                string val = "VM_" + e.PropertyName;
                if (val.Equals("VM_Throttle") || val.Equals("VM_Aileron") || val.Equals("VM_Elevator") ||
                val.Equals("VM_Rudder"))
                {
                    NotifyPropertyChanged(val);
                }
            };
        }
        public double VM_Throttle
        {
            get
            {
                return Math.Round(model.Throttle, 2);
            }
        }

        public double VM_Aileron
        {
            get
            {
                return Math.Round(model.Aileron, 2);
            }
        }

        public double VM_Elevator
        {
            get
            {
                return Math.Round(model.Elevator, 2);
            }
        }

        public double VM_Rudder
        {
            get
            {
                return Math.Round(model.Rudder, 2);
            }
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
