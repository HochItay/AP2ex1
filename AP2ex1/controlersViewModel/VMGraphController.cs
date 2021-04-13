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
        private controlersModel.IMGraphController model;

        private VMLinesGraph vmLGraph;
        private VMLinesGraph vmCLGraph;
        private VMDotsGraph vmDGraph;

        public DependencyProperty LPlotModel = DependencyProperty.Register("LPlotModel", typeof(PlotModel), typeof(VMGraphController));
        public DependencyProperty CLPlotModel = DependencyProperty.Register("CLPlotModel", typeof(PlotModel), typeof(VMGraphController));
        public DependencyProperty DPlotModel = DependencyProperty.Register("DPlotModel", typeof(PlotModel), typeof(VMGraphController));

        private IList<string> varsList;
        public IList<string> VarsList
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

        public VMGraphController(controlersModel.IMGraphController model)
        {
            this.model = model;

            vmLGraph = new VMLinesGraph(model);
            
            BindingOperations.SetBinding(this, LPlotModel,
            new Binding("PlotModel") { Source = vmLGraph, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

            vmCLGraph = new VMLinesGraph(model);
            BindingOperations.SetBinding(this, CLPlotModel,
            new Binding("PlotModel") { Source = vmCLGraph, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
            

            vmDGraph = new VMDotsGraph(model, model.GedNumPointsPerSec());
            BindingOperations.SetBinding(this, DPlotModel,
            new Binding("PlotModel") { Source = vmDGraph, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

            VarsList = model.GetVarsNames();

            SetGraphs();   
        }

        private void SetGraphs()
        {
            vmLGraph.SetTitle("Choosen Variable Graph");
            vmCLGraph.SetTitle("Correlative Variable Graph");
            vmDGraph.SetTitle("Anomaly Detection Graph");
        }

        public void RestartGraphs(string var)
        {
            string corrilativeVar = model.GetCorrelativeVar(var);
            //set Axes tiltels
            vmLGraph.SetXTitle("time");
            vmLGraph.SetYTitle(var);

            vmCLGraph.SetXTitle("time");
            vmCLGraph.SetYTitle(corrilativeVar);

            vmDGraph.SetXTitle(var);
            vmDGraph.SetYTitle(corrilativeVar);

            vmLGraph.SetGraphData(model.GetVarPoints(var));
            vmCLGraph.SetGraphData(model.GetVarPoints(corrilativeVar));

            Tuple<IList<Point>, IList<Point>> anomalyPoints= model.GetAnomalyGraphPoints(var, corrilativeVar);
            vmDGraph.SetGraphData(anomalyPoints.Item1, anomalyPoints.Item2, model.GetRegressionFuncs());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
