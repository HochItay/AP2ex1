using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.controlersViewModel
{
    class VMMediaController : IVMMediaController
    {
        private double speed = 1;
        private int videoLength = 1000;
        private int videoCurrentTime = 500;
        private bool isRunning;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public double VM_Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = Math.Round(value, 1);
                NotifyPropertyChanged("VM_Speed");
            }
        }
        public int VM_VideoLength {
            get
            {
                return videoLength;
            } 
        }
        public int VM_VideoCurrentTime
        {
            get
            {
                return videoCurrentTime;
            }
            set
            {
                videoCurrentTime = value;
                NotifyPropertyChanged("VM_VideoCurrentTime");
            }
        }
        public bool VM_VideoIsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                isRunning = value;
                NotifyPropertyChanged("VM_VideoIsRunning");

            }
        }

        public void startOver()
        {
            VM_VideoCurrentTime = 0;
            isRunning = true;
        }
        
        public void goToEnd()
        {
            VM_VideoCurrentTime = videoLength;
            isRunning = false;
        }
        public void skipTen()
        {
            VM_VideoCurrentTime += 10;
        }
        public void goBackTen()
        {
            VM_VideoCurrentTime -= 10;
        }
        public void playClicked()
        {
            if (isRunning) { VM_VideoIsRunning = false;  }
            else { VM_VideoIsRunning = true; }

        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
