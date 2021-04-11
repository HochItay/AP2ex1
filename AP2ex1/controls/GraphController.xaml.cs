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
        private controlersViewModel.VMLinesGraph vmLGraph;
        private controlersViewModel.VMLinesGraph vmCLGraph;
        private controlersViewModel.VMDotsGraph vmDGraph;

        public GraphController()
        {
            InitializeComponent();

            CBDisplay.Text = CB_PLACE_HOLDER;

            vmLGraph = new controlersViewModel.VMLinesGraph();
            LGraph.Model = vmLGraph.PlotModel;
            vmLGraph.PlotModel.LegendTitle = "Choosen Variable Graph";

            vmCLGraph = new controlersViewModel.VMLinesGraph();
            CLGraph.Model = vmCLGraph.PlotModel;
            vmCLGraph.PlotModel.LegendTitle = "Correlative Variable Graph";

            vmDGraph = new controlersViewModel.VMDotsGraph();
            DGraph.Model = vmDGraph.PlotModel;
            vmDGraph.PlotModel.LegendTitle = "Anomaly Detection Graph";


            CBDisplay.ItemsSource = new List<string>() {"a","b","c"};
        }

        private void DisplayGraphs(object sender, RoutedEventArgs e)
        {
            if(CBDisplay.Text.Equals(CB_PLACE_HOLDER))
            {
                return;
            }

        }

    }
}
