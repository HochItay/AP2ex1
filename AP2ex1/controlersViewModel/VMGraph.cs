using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace AP2ex1.controlersViewModel
{
    abstract class VMGraph: INotifyPropertyChanged
    {
        protected Axis xAxe;
        protected Axis yAxe;
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
                    OnPropertyChanged("PlotModel");
                }
            }
        }

        public VMGraph()
        {
            PlotModel = new PlotModel();
            SetUpModel();
            
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
