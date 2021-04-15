using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.Model
{
    public interface IMMediaController : INotifyPropertyChanged
    {
        /// <summary>
        /// the video's speed
        /// </summary>
        double VideoSpeed { set; get; }

        /// <summary>
        /// the video's length
        /// </summary>
        int VideoLength { get; }

        /// <summary>
        /// the video's currnet time
        /// </summary>
        int VideoCurrentTime { get; set; }

        /// <summary>
        /// the bool to determine if the video is running
        /// </summary>
        bool VideoIsRunning { get; set; }

        /// <summary>
        /// Go to the start of the video.
        /// </summary>
        void StartOver();

        /// <summary>
        /// Go to the end of the video.
        /// </summary>
        void GoToEnd();

        /// <summary>
        /// skip te sec
        /// </summary>
        void SkipTen();

        /// <summary>
        /// go beck ten sec
        /// </summary>
        void GoBackTen();

        /// <summary>
        /// to play or stop the video => (the play button was pressed)
        /// </summary>
        void PlayClicked();
    }
}
