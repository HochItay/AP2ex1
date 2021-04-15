using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.ViewModel
{
    /// <summary>
    /// This is the VM for the media controller.
    /// It has the video speed, video lenght, video current time, and is video running
    /// properties. all of the properties has  getters because  the model can change them, and few have setters because the view
    /// can change them (meaning the user through the UI)
    /// the vm implement the INotifyPropertyChanged in order to notify the view when the values are changing.
    /// </summary>
    public interface IVMMediaController : INotifyPropertyChanged
    {
        /// <summary>
        /// the speed of the video.
        /// </summary>
        double VM_VideoSpeed { set; get; }
        /// <summary>
        /// the lenght of the video
        /// </summary>
        int VM_VideoLength { get; }
        /// <summary>
        /// the current time in the video.
        /// </summary>
        int VM_VideoCurrentTime { get; set; }
        /// <summary>
        /// boo that is true if the video is running.
        /// </summary>
        bool VM_VideoIsRunning { get; set; }

        /// <summary>
        /// all of the vm func cals the model in order that the mode will change its own data.
        /// </summary>

        /// <summary>
        /// set the current time to zero
        /// </summary>
        void StartOver();
        /// <summary>
        /// set the current time to the end.
        /// </summary>
        void GoToEnd();
        /// <summary>
        /// skip the seconds
        /// </summary>
        void SkipTen();
        /// <summary>
        /// go back ten seconds in the video
        /// </summary>
        void GoBackTen();
        /// <summary>
        /// tells the mode that the play buttun has been clicked.
        /// </summary>
        void PlayClicked();
    }
}
