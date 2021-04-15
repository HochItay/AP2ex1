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
        /// <summary>
        /// this func calls property changed for this class with the given property name.
        /// </summary>
        /// <param name="propName"> the name of the property that changed</param>
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public VMYPRDisplayer(Model.IMYPRDisplayer model)
        {
            this.model = model;
            // add a delegate to the model that when the model is changing is notify this vm about the change.
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                //we are clling the NotifyPropertyChanged only whenever the properties of this vm are change
                string val = "VM_" + e.PropertyName;
                if (val.Equals("VM_Yaw") || val.Equals("VM_Pitch") || val.Equals("VM_Roll"))
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
