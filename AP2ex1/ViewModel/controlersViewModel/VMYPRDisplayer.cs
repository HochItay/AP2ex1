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
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public VMYPRDisplayer(Model.IMYPRDisplayer model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                string var = "VM_" + e.PropertyName;
                if (var.Equals("VM_Yaw") || var.Equals("VM_Pitch") || var.Equals("VM_Roll"))
                {
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                }
            };
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

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
