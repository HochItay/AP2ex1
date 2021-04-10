﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AP2ex1.controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MediaController : UserControl
    {
        private double speed = 1;
        public double Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = Math.Round(value, 3);
            }
        }
        public MediaController()
        {
            InitializeComponent();
        }
    }
}
