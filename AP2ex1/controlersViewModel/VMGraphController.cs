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
                plotModel = value;
                OnPropertyChanged("PlotModel"); 
            }
        }

        public VMGraphController()
        {
            PlotModel = new PlotModel();
            SetUpModel();
            Func<double, double> batFn1 = (x) => Math.Sqrt(5-Math.Pow(x,2));
            PlotModel.Series.Add(new FunctionSeries(batFn1, 0, 5, 0.00001));
        }

        private void SetUpModel()
        {
            PlotModel.LegendTitle = "Dots Graph";
            PlotModel.LegendTitleFontSize = 20;
            PlotModel.LegendOrientation = LegendOrientation.Horizontal;
            PlotModel.LegendPlacement = LegendPlacement.Outside;
            PlotModel.LegendPosition = LegendPosition.TopCenter;

            var dateAxis = new TimeSpanAxis() {Position = AxisPosition.Bottom, StringFormat = "mm:ss"};
            PlotModel.Axes.Add(dateAxis);
            var valueAxis = new LinearAxis() {Position = AxisPosition.Left};
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
