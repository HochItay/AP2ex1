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

namespace AP2ex1.controls
{
    /// <summary>
    /// Interaction logic for GraphController.xaml
    /// </summary>
    public partial class GraphController : UserControl
    {
        private readonly string CB_PLACE_HOLDER = "Choose Variable To Display";
        private string lastVarToDisplay = "";

        private controlersViewModel.VMGraphController vmGraphController;
        public GraphController()
        {
            InitializeComponent();

            CBDisplay.Text = CB_PLACE_HOLDER;

            DataContext = vmGraphController;

        }

        private void DisplayGraphs(object sender, RoutedEventArgs e)
        {
            if (CBDisplay.Text.Equals(CB_PLACE_HOLDER) || CBDisplay.Text.Equals(lastVarToDisplay))
            {
                return;
            }

            lastVarToDisplay = CBDisplay.Text;
            vmGraphController.RestartGraphs(CBDisplay.Text);
        }

    }
}
