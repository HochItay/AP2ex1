using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace AP2ex1.ViewModel
{
    /// <summary>
    /// This is the class that handels the garph controller.
    /// </summary>
    public class VMGraphController : DependencyObject, INotifyPropertyChanged
    {
        private Model.IMGraphController model;

        private VMLinesGraph vmLGraph;
        private VMLinesGraph vmCLGraph;
        private VMDotsGraph vmDGraph;

        /// <summary>
        /// The data of the var lines graph.
        /// </summary>
        public DependencyProperty LPlotModel = DependencyProperty.Register("LPlotModel", typeof(PlotModel), typeof(VMGraphController));

        /// <summary>
        /// The data of the correlative var lines graph.
        /// </summary>
        public DependencyProperty CLPlotModel = DependencyProperty.Register("CLPlotModel", typeof(PlotModel), typeof(VMGraphController));

        /// <summary>
        /// The data of the anomaly (dots) graph.
        /// </summary>
        public DependencyProperty DPlotModel = DependencyProperty.Register("DPlotModel", typeof(PlotModel), typeof(VMGraphController));

        /// <summary>
        /// the list of the vars names you can display.
        /// </summary>
        public IList<string> VM_VarsNames
        {
            get
            {
                return model.VarsNames;
            }

        }

        /// <summary>
        /// The time and the points of the anomaly points.
        /// </summary>
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

        /// <summary>
        /// Constructor of this class.
        /// </summary>
        /// <param name="model">the model to get data from</param>
        public VMGraphController(Model.IMGraphController model)
        { 
            this.model = model;

            //adding to the model the property to updates.
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {

                string varName = "VM_" + e.PropertyName;
                if (varName.Equals("VM_VarsNames"))
                {
                    NotifyPropertyChanged(varName);
                }
            };

            //creating the var graph.
            vmLGraph = new VMLinesGraph(model);
            
            //binding the var's graph data to the correct property.
            BindingOperations.SetBinding(this, LPlotModel,
            new Binding("PlotModel") { Source = vmLGraph, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

            //creating the correlative var graph.
            vmCLGraph = new VMLinesGraph(model);

            //binding the correlative var's graph data to the correct property.
            BindingOperations.SetBinding(this, CLPlotModel,
            new Binding("PlotModel") { Source = vmCLGraph, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
            
            //creating the anomaly graph.
            vmDGraph = new VMDotsGraph(model, model.GetNumPointsPerSec());

            //binding the anomaly's graph data to the correct property.
            BindingOperations.SetBinding(this, DPlotModel,
            new Binding("PlotModel") { Source = vmDGraph, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

            //sets the graph's titles
            SetGraphs();   
        }

        /// <summary>
        /// Sets the graphs main titles
        /// </summary>
        private void SetGraphs()
        {
            vmLGraph.SetTitle("Chosen Variable Graph");
            vmCLGraph.SetTitle("Correlative Variable Graph");
            vmDGraph.SetTitle("Anomaly Detection Graph");
        }

        /// <summary>
        /// When another var is chosen to display the graphs should restart.
        /// </summary>
        /// <param name="varName">the new var to check</param>
        public void RestartGraphs(string varName)
        {
            //gets the corrilative var
            string corrilativeVar = model.GetCorrelativeVar(varName);

            //set Axes titles.
            vmLGraph.SetXTitle("time");
            vmLGraph.SetYTitle(varName);

            vmCLGraph.SetXTitle("time");
            vmCLGraph.SetYTitle(corrilativeVar);

            vmDGraph.SetXTitle(varName);
            vmDGraph.SetYTitle(corrilativeVar);

            //sets the lines graph data
            vmLGraph.SetGraphData(model.GetVarPoints(varName));
            vmCLGraph.SetGraphData(model.GetVarPoints(corrilativeVar));

            //gets the anomaly's graph points data
            Tuple<IList<Point>, IList<Tuple<TimeSpan, Point>>> anomalyPoints= model.GetAnomalyGraphPoints(varName, corrilativeVar);

            //sets the property of the anomaly points
            MarkedPoints = anomalyPoints.Item2;

            //sets the anomaly graph data.
            vmDGraph.SetGraphData(anomalyPoints.Item1, GetOnlyAnomalyPoints(anomalyPoints.Item2), model.GetGraphFuncs(varName));
        }

        /// <summary>
        /// gets only yhe points of the anomaly.
        /// </summary>
        /// <param name="anomalyData"></param>
        /// <returns></returns>
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
