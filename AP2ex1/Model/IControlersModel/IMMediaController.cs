﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.Model
{
    public interface IMMediaController : INotifyPropertyChanged
    {
        double VideoSpeed { set; get; }
        int VideoLength { get; }
        int VideoCurrentTime { get; set; }
        bool VideoIsRunning { get; set; }
        void StartOver();
        void GoToEnd();
        void SkipTen();
        void GoBackTen();
        void PlayClicked();
    }
}
