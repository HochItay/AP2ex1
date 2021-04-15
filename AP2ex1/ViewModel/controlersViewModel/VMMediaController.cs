using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.ViewModel
{
    class VMMediaController : IVMMediaController
    {
        Model.IMMediaController model;
        
        public double VM_VideoSpeed
        {
            get
            {
                return model.VideoSpeed;
            }
            set
            {
               //call the notify property change only if the vaue really changed.
                if (model.VideoSpeed != value) {
                    //we round the value one digit after the dot.
                    model.VideoSpeed = Math.Round(value, 1);
                    NotifyPropertyChanged("VM_VideoSpeed");
                }
            }
        }

        public int VM_VideoLength {
            get
            {
                return model.VideoLength;
            } 
        }

        public int VM_VideoCurrentTime
        {
            get
            {
                return model.VideoCurrentTime;
            }
            set
            {
                if (model.VideoCurrentTime != value)
                {
                    if (model.VideoCurrentTime != value)
                    {
                        model.VideoCurrentTime = value;
                        NotifyPropertyChanged("VM_VideoCurrentTime");
                    }
                }
            }
        }
        public bool VM_VideoIsRunning
        {
            get
            {
                return model.VideoIsRunning;
            }
            set
            {
                if (model.VideoIsRunning != value) {
                    model.VideoIsRunning = value;
                    NotifyPropertyChanged("VM_VideoIsRunning");
                }
            }
        }

        public VMMediaController(Model.IMMediaController model)
        {
            this.model = model;
            // add a delegate to the model that when the model is changing is notify this vm about the change.
            this.model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                string val = "VM_" + e.PropertyName;
                //we are clling the NotifyPropertyChanged only whenever the properties of this vm are change
                if (val.Equals("VM_VideoSpeed") || val.Equals("VM_VideoLength") ||
                val.Equals("VM_VideoCurrentTime") || val.Equals("VM_VideoIsRunning"))
                {
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                }
            };
        }

        public void StartOver()
        {
            model.StartOver();
        }
        
        public void GoToEnd()
        {
            model.GoToEnd();
        }
        public void SkipTen()
        {
            model.SkipTen();
        }
        public void GoBackTen()
        {
            model.GoBackTen();
        }
        public void PlayClicked()
        {
            model.PlayClicked();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// this func calls property changed for this class with the given property name.
        /// </summary>
        /// <param name="propName"> the name of the property that changed</param>
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
