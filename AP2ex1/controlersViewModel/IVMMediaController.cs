using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.controlersViewModel
{
    interface IVMMediaController : INotifyPropertyChanged
    {
        double VM_Speed
        {
            set;
            get;
        }
        int VM_VideoLength { get; }
        int VM_VideoCurrentTime { get; set; }
        bool VM_VideoIsRunning { get; set; }
        //the model don't need to implement the strings.
        //string VM_VideoLengthStr { get; }
        //string VM_VideoCurrentTimeStr { get; set; }
        void startOver();
        void goToEnd();
        void skipTen();
        void goBackTen();
        void playClicked();
    }
}
