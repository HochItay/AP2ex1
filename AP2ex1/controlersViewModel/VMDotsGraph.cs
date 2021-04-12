using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.controlersViewModel
{
    class VMDotsGraph: VMGraph
    {
        private IList<ScatterPoint> points;
        private IList<ScatterPoint> markedPoints;

        public VMDotsGraph()
        {
            var dateAxis = new LinearAxis() { Position = AxisPosition.Bottom};
            PlotModel.Axes.Add(dateAxis);
        }

        public void setGraphData(IList<ScatterPoint> points)
        {
            PlotModel.Series.Clear();

            this.points = points;
            PlotModel.Series.Add(new ScatterSeries()
                {
                    ItemsSource = this.points,
                    MarkerFill = OxyColors.Black,
                    MarkerType = MarkerType.Circle
                });
            

            PlotModel.Series.Add(new LineSeries() { ItemsSource = this.points });


            markedPoints = new List<ScatterPoint>();
            PlotModel.Series.Add(new ScatterSeries()
            {
                ItemsSource = markedPoints,
                MarkerFill = OxyColors.Red,
                MarkerType = OxyPlot.MarkerType.Circle
            });
        }

        public void addPoints(IList<ScatterPoint> points)
        {
            foreach (ScatterPoint point in points)
            {
                this.points.Add(point);
            }

            PlotModel.InvalidatePlot(true);
        }

        public void addMarkedPoints(IList<ScatterPoint> points)
        {
            foreach (ScatterPoint point in points)
            {
                markedPoints.Add(point);
            }

            PlotModel.InvalidatePlot(true);
        }

        public void setRegressionFunc(IList<Tuple<Func<double,double>, double, double>> regFuncs, double maxValue, double minValue)
        {
            foreach (var funcSeries in regFuncs)
            {
                Func<double, double> func = funcSeries.Item1;
                double start = funcSeries.Item2;
                double end = funcSeries.Item3;

                if(Double.IsInfinity(start))
                {
                    start = minValue;
                }

                if (Double.IsInfinity(end))
                {
                    end = maxValue;
                }

                PlotModel.Series.Add(new FunctionSeries(func, start, end, 0.0001));
            }
        }
    }
}
