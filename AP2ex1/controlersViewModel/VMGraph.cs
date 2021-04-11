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

        public VMGraph()
        {
            PlotModel = new PlotModel();
            SetUpModel();
            
        }

        private void SetUpModel()
        {
            PlotModel.LegendTitleFontSize = 15;
            PlotModel.LegendOrientation = LegendOrientation.Horizontal;
            PlotModel.LegendPlacement = LegendPlacement.Outside;
            PlotModel.LegendPosition = LegendPosition.TopCenter;

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
