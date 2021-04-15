using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace AP2ex1.ViewModel
{
    /// <summary>
    /// This is an abstruct class that is used
    /// for saving code, in here you would find 
    /// the shared code for specific classes.
    /// </summary>
    abstract class AVMGraph : INotifyPropertyChanged
    {
        protected static readonly int START_POINT_INDEX = 0;
        protected Axis xAxe;
        protected Axis yAxe;
        private Model.IMGraph model;
        protected Thread thread;

        /// <summary>
        /// This is a the plot modle witch saves data on the graph.
        /// </summary>
        private PlotModel plotModel;
        public PlotModel PlotModel
        {
            get 
            {
                return plotModel; 
            }

            set
            {
                if (plotModel != value)
                {
                    plotModel = value;
                    NotifyPropertyChanged("PlotModel");
                }
            }
        }

        /// <summary>
        /// This is the current line witch is fed to the flight geer.
        /// </summary>
        public int VM_CurrentLine
        {
            get
            {
                return model.CurrentLine;
            }
        }

        /// <summary>
        /// Constructor for shared intializations. 
        /// </summary>
        /// <param name="model">This is the model that gives the data to the graph</param>
        public AVMGraph(Model.IMGraph model)
        {
            PlotModel = new PlotModel();

            //set shared data on graphs
            SetUpModel();

            //adding thread to run updates on the graphs
            thread = new Thread(new ThreadStart(updateWithThread));


            this.model = model;
        }

        /// <summary>
        /// Func to fed the thred that would updates the graph.
        /// </summary>
        private void updateWithThread()
        {
            while(true)
            {
                UpdateGraphPoints();

                //we wait 200 ms between updates
                Thread.Sleep(200);
            }
        }

        /// <summary>
        /// Sets the graph's title
        /// </summary>
        /// <param name="title">the title to set </param>
        public void SetTitle(string title)
        {
            PlotModel.LegendTitle = title;
        }

        /// <summary>
        /// Sets the title of Y Axe
        /// </summary>
        /// <param name="title">the title to set</param>
        public void SetYTitle(string title)
        {
            yAxe.Title = title;
            PlotModel.InvalidatePlot(true);
        }

        /// <summary>
        /// Sets the title of X Axe
        /// </summary>
        /// <param name="title">the title to set</param>
        public void SetXTitle(string title)
        {
            xAxe.Title = title;
            PlotModel.InvalidatePlot(true);
        }

        /// <summary>
        /// Sets data on the graph
        /// </summary>
        private void SetUpModel()
        {
            //Sets the look of the Graph title
            PlotModel.LegendTitleFontSize = 15;
            PlotModel.LegendOrientation = LegendOrientation.Horizontal;
            PlotModel.LegendPlacement = LegendPlacement.Outside;
            PlotModel.LegendPosition = LegendPosition.TopCenter;

            //Sets Y Axe of the graph
            yAxe = new LinearAxis() {Position = AxisPosition.Left};
            PlotModel.Axes.Add(yAxe);
        }

        /// <summary>
        /// updates the graphs point. 
        /// </summary>
        public abstract void UpdateGraphPoints();
        
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies this PropertyChanged with the propety that changed
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
