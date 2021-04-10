using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Axes;

namespace AP2ex1.controlersViewModel
{
    class VMGraphController: INotifyPropertyChanged
    {
        private PlotModel plotModel;
        public PlotModel PlotModel
        {
            get 
            {
                return plotModel; 
            }

            set
            { 
                plotModel = value; OnPropertyChanged("PlotModel"); 
            }
        }

        public VMGraphController()
        {
            PlotModel = new PlotModel();
            SetUpModel();
        }

        private void SetUpModel()
        {
            PlotModel.LegendTitle = "Legend";
            PlotModel.LegendTitleFontSize = 20;
            PlotModel.LegendOrientation = LegendOrientation.Horizontal;
            PlotModel.LegendPlacement = LegendPlacement.Outside;
            PlotModel.LegendPosition = LegendPosition.TopCenter;

            var dateAxis = new DateTimeAxis() { Position = AxisPosition.Bottom, Title = "Time", StringFormat = "mm:ss", MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, IntervalLength = 80 };
            PlotModel.Axes.Add(dateAxis);
            var valueAxis = new LinearAxis() {Position = AxisPosition.Left, StartPosition = 0,MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Title = "Value" };
            PlotModel.Axes.Add(valueAxis);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
