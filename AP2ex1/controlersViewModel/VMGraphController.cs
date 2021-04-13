using OxyPlot;
using OxyPlot.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace AP2ex1.controlersViewModel
{

    class VMGraphController : DependencyObject, INotifyPropertyChanged
    {
        private VMLinesGraph vmLGraph;
        private VMLinesGraph vmCLGraph;
        private VMDotsGraph vmDGraph;

        public DependencyProperty LPlotModel = DependencyProperty.Register("LPlotModel", typeof(PlotModel), typeof(VMGraphController));
        public DependencyProperty CLPlotModel = DependencyProperty.Register("CLPlotModel", typeof(PlotModel), typeof(VMGraphController));
        public DependencyProperty DPlotModel = DependencyProperty.Register("DPlotModel", typeof(PlotModel), typeof(VMGraphController));
        private List<string> varsList;
        public List<string> VarsList
        {
            get
            {
                return varsList;
            }

            set
            {
                if (varsList != value)
                {
                    varsList = value;
                    OnPropertyChanged("VarsList");
                }
            }

        }
        public VMGraphController()
        {
            
            vmLGraph = new VMLinesGraph();
            
            BindingOperations.SetBinding(this, LPlotModel,
            new Binding("PlotModel") { Source = vmLGraph, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

            vmCLGraph = new VMLinesGraph();
            BindingOperations.SetBinding(this, CLPlotModel,
            new Binding("PlotModel") { Source = vmCLGraph, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
            

            vmDGraph = new VMDotsGraph();
            BindingOperations.SetBinding(this, DPlotModel,
            new Binding("PlotModel") { Source = vmDGraph, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
            
            
            vmLGraph.SetTitle("Choosen Variable Graph");
            vmCLGraph.SetTitle("Correlative Variable Graph");
            vmDGraph.SetTitle("Anomaly Detection Graph");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
