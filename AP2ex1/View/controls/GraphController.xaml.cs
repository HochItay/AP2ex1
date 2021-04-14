﻿using AP2ex1.ViewModel;
using OxyPlot;
using OxyPlot.Series;
using System;
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

namespace AP2ex1.View
{
    /// <summary>
    /// Interaction logic for GraphController.xaml
    /// </summary>
    public partial class GraphController : UserControl
    {
        private readonly string CB_PLACE_HOLDER = "Choose Variable To Display";
        private string lastVarToDisplay = "";

        private ViewModel.VMGraphController vm;
        public VMGraphController VM
        {
            set
            {
                vm = value;
                DataContext = vm;
            }
        }
        public GraphController()
        {
            InitializeComponent();

            CBDisplay.Text = CB_PLACE_HOLDER;
        }

        private void DisplayGraphs(object sender, RoutedEventArgs e)
        {
            if (CBDisplay.Text.Equals(CB_PLACE_HOLDER) || CBDisplay.Text.Equals(lastVarToDisplay))
            {
                return;
            }

            lastVarToDisplay = CBDisplay.Text;
            vm.RestartGraphs(CBDisplay.Text);
        }

    }
}
