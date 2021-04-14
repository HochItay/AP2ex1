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
        public VMMediaController(Model.IMMediaController model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                string var = "VM_" + e.PropertyName;
                if(var.Equals("VM_VideoSpeed") || var.Equals("VM_VideoLength") ||
                var.Equals("VM_VideoCurrentTime") || var.Equals("VM_VideoIsRunning"))
                {
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                }
            };
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public double VM_VideoSpeed
        {
            get
            {
                return model.VideoSpeed;
            }
            set
            {
                if (model.VideoSpeed != value) {
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
                    model.VideoCurrentTime = value;
                    NotifyPropertyChanged("VM_VideoCurrentTime");
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

    }
}
