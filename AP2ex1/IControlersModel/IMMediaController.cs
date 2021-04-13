using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.IControlersModel
{
    interface IMMediaController
    {
        double VideoSpeed { set; get; }
        int VideoLength { get; }
        int VideoCurrentTime { get; set; }
        bool VideoIsRunning { get; set; }
        void startOver();
        void goToEnd();
        void skipTen();
        void goBackTen();
        void playClicked();
    }
}
