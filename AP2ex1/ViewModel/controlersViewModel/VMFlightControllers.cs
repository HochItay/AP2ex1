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
        public VMFlightControllers()
        {

        }
        public VMFlightControllers(Model.IMFlightControllers model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                string var = "VM_" + e.PropertyName;
                if (var.Equals("VM_Throttle") || var.Equals("VM_Aileron") || var.Equals("VM_Elevetor") ||
                var.Equals("VM_Ruddel"))
                {
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                }
            };
        }
        public double VM_Throttle
        {
            get
            {
                //return model.Throttle;
                return 0.5;
            }
        }

        public double VM_Aileron
        {
            get
            {
                //return model.Aileron;
                return 0.1;
            }
        }

        public double VM_Elevetor
        {
            get
            {
                //return model.Elevetor;
                return 0.3;
            }
        }

        public double VM_Ruddel
        {
            get
            {
                //return model.Ruddel;
                return 0;
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
