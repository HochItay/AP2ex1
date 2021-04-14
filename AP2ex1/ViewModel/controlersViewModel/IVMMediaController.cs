using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.ViewModel
{
    interface IVMMediaController : INotifyPropertyChanged
    {
        double VM_VideoSpeed { set; get; }
        int VM_VideoLength { get; }
        int VM_VideoCurrentTime { get; set; }
        bool VM_VideoIsRunning { get; set; }
        void StartOver();
        void GoToEnd();
        void SkipTen();
        void GoBackTen();
        void PlayClicked();
    }
}
