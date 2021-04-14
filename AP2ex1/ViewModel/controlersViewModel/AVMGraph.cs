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
    abstract class AVMGraph : INotifyPropertyChanged
    {
        protected static readonly int START_POINT_INDEX = 0;
        protected Axis xAxe;
        protected Axis yAxe;
        private Model.IMGraph model;
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

        public int VM_CurrentLine
        {
            get
            {
                return model.CurrentLine;
            }
        }

        public AVMGraph(Model.IMGraph model)
        {
            PlotModel = new PlotModel();
            SetUpModel();

            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) {
                string var = "VM_" + e.PropertyName;
                if (var.Equals("VM_CurrentLine")) {
                    Thread thread = new Thread(new ThreadStart(UpdateGraphPoints));
                    thread.Start();
                }
            };
        }

        public void SetTitle(string title)
        {
            PlotModel.LegendTitle = title;
        }

        public void SetYTitle(string title)
        {
            yAxe.Title = title;
            PlotModel.InvalidatePlot(true);
        }

        public void SetXTitle(string title)
        {
            xAxe.Title = title;
            PlotModel.InvalidatePlot(true);
        }

        private void SetUpModel()
        {
            PlotModel.LegendTitleFontSize = 15;
            PlotModel.LegendOrientation = LegendOrientation.Horizontal;
            PlotModel.LegendPlacement = LegendPlacement.Outside;
            PlotModel.LegendPosition = LegendPosition.TopCenter;

            yAxe = new LinearAxis() {Position = AxisPosition.Left};
            PlotModel.Axes.Add(yAxe);
        }
        public abstract void UpdateGraphPoints();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
