using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AP2ex1.controlersViewModel
{
    class VMDotsGraph: AVMGraph
    {
        private static readonly int LAST_SECS_TO_DISPLAY = 30;
        private List<ScatterPoint> allPoints;
        private List<ScatterPoint> displayedPoints;
        private int pointsPerSec;
        private bool isDataIntialized = false;
        public VMDotsGraph(IControlersModel.IMGraph model, int pointsPerSec) : base(model)
        {
            xAxe = new LinearAxis() { Position = AxisPosition.Bottom};
            PlotModel.Axes.Add(xAxe);

            this.pointsPerSec = pointsPerSec;
        }

        public void SetGraphData(IList<Point> allPoints, IList<Point> allMarkedPoints, IList<Tuple<Func<double, double>, double, double>> regFuncs)
        {
            PlotModel.Series.Clear();

            this.allPoints = GetDataPointList(allPoints, allMarkedPoints);

            displayedPoints = displayedPoints.GetRange(START_POINT_INDEX, START_POINT_INDEX);

            ScatterSeries scatter = new ScatterSeries()
            {
                ItemsSource = displayedPoints,
                MarkerType = MarkerType.Circle
            };

            PlotModel.Series.Add(scatter);

            SetRegressionFunc(regFuncs, scatter.MinX, scatter.MaxX);

            isDataIntialized = true;
            UpdateGraphPoints();
        }

        private List<ScatterPoint> GetDataPointList(IList<Point> allPoints, IList<Point> allMarkedPoints)
        {
            List<ScatterPoint> scatterPoints = new List<ScatterPoint>();

            foreach (Point point in allPoints)
            {
                ScatterPoint scatterPoint = new ScatterPoint(point.X, point.Y);

                if (allMarkedPoints.Contains(point))
                {
                    scatterPoint.Value = 0;//RED
                } else
                {
                    scatterPoint.Value = 1;//BLUE
                }

                scatterPoints.Add(scatterPoint);
            }

            return scatterPoints;
        }

        public override void UpdateGraphPoints()
        {   
            if(!isDataIntialized)
            {
                return;
            }

            int numPointsToDisplay = LAST_SECS_TO_DISPLAY * pointsPerSec;
            int startIndex = VM_CurrentLine - numPointsToDisplay;
            if (startIndex < 0)
            {
                startIndex = 0;
                numPointsToDisplay = VM_CurrentLine;
            }

            displayedPoints = allPoints.GetRange(startIndex, numPointsToDisplay);
            PlotModel.InvalidatePlot(true);
        }

        private void SetRegressionFunc(IList<Tuple<Func<double,double>, double, double>> regFuncs, double maxValue, double minValue)
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
