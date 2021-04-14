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
                model.VideoSpeed = Math.Round(value, 1);
                NotifyPropertyChanged("VM_VideoSpeed");
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
                model.VideoCurrentTime = value;
                NotifyPropertyChanged("VM_VideoCurrentTime");
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
                model.VideoIsRunning = value;
                NotifyPropertyChanged("VM_VideoIsRunning");

            }
        }

        public void startOver()
        {
            model.startOver();
        }
        
        public void goToEnd()
        {
            model.goToEnd();
        }
        public void skipTen()
        {
            model.skipTen();
        }
        public void goBackTen()
        {
            model.goBackTen();
        }
        public void playClicked()
        {
            model.playClicked();

        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
