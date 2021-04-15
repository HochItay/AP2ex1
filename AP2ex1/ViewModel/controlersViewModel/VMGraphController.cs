using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace AP2ex1.ViewModel
{

    public class VMGraphController : DependencyObject, INotifyPropertyChanged
    {
        private Model.IMGraphController model;

        private VMLinesGraph vmLGraph;
        private VMLinesGraph vmCLGraph;
        private VMDotsGraph vmDGraph;

        public DependencyProperty LPlotModel = DependencyProperty.Register("LPlotModel", typeof(PlotModel), typeof(VMGraphController));
        public DependencyProperty CLPlotModel = DependencyProperty.Register("CLPlotModel", typeof(PlotModel), typeof(VMGraphController));
        public DependencyProperty DPlotModel = DependencyProperty.Register("DPlotModel", typeof(PlotModel), typeof(VMGraphController));

        public IList<string> VM_VarsNames
        {
            get
            {
                return model.VarsNames;
            }

        }

        IList<Tuple<TimeSpan, Point>> markedPoints;
        public IList<Tuple<TimeSpan, Point>> MarkedPoints
        {
            get => markedPoints;
            set
            {
                markedPoints = value;
                NotifyPropertyChanged("MarkedPoints");
            }
        }

        public VMGraphController(Model.IMGraphController model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {

                string varName = "VM_" + e.PropertyName;
                if (varName.Equals("VM_VarsNames"))
                {
                    NotifyPropertyChanged(varName);
                }
            };

            vmLGraph = new VMLinesGraph(model);
            
            BindingOperations.SetBinding(this, LPlotModel,
            new Binding("PlotModel") { Source = vmLGraph, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

            vmCLGraph = new VMLinesGraph(model);
            BindingOperations.SetBinding(this, CLPlotModel,
            new Binding("PlotModel") { Source = vmCLGraph, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
            

            vmDGraph = new VMDotsGraph(model, model.GetNumPointsPerSec());
            BindingOperations.SetBinding(this, DPlotModel,
            new Binding("PlotModel") { Source = vmDGraph, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

            SetGraphs();   
        }

        private void SetGraphs()
        {
            vmLGraph.SetTitle("Chosen Variable Graph");
            vmCLGraph.SetTitle("Correlative Variable Graph");
            vmDGraph.SetTitle("Anomaly Detection Graph");
        }

        public void RestartGraphs(string varName)
        {

            string corrilativeVar = model.GetCorrelativeVar(varName);
            //set Axes titles.
            vmLGraph.SetXTitle("time");
            vmLGraph.SetYTitle(varName);

            vmCLGraph.SetXTitle("time");
            vmCLGraph.SetYTitle(corrilativeVar);

            vmDGraph.SetXTitle(varName);
            vmDGraph.SetYTitle(corrilativeVar);

            vmLGraph.SetGraphData(model.GetVarPoints(varName));
            vmCLGraph.SetGraphData(model.GetVarPoints(corrilativeVar));

            Tuple<IList<Point>, IList<Tuple<TimeSpan, Point>>> anomalyPoints= model.GetAnomalyGraphPoints(varName, corrilativeVar);
            MarkedPoints = anomalyPoints.Item2;
            vmDGraph.SetGraphData(anomalyPoints.Item1, GetOnlyAnomalyPoints(anomalyPoints.Item2), model.GetGraphFuncs(varName));
        }

        private IList<Point> GetOnlyAnomalyPoints(IList<Tuple<TimeSpan, Point>> anomalyData)
        {
            List<Point> anomalyPoints = new List<Point>();
            foreach(var data in anomalyData)
            {
                anomalyPoints.Add(new Point(data.Item2.X, data.Item2.Y));
            }

            return anomalyPoints;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
