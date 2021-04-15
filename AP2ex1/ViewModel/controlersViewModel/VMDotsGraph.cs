using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AP2ex1.ViewModel
{
    class VMDotsGraph: AVMGraph
    {
        private static readonly int LAST_SECS_TO_DISPLAY = 30;
        private List<ScatterPoint> allPoints;
        private ScatterSeries displayedPoints;
        private List<ScatterPoint> allMarkedPoints;
        private ScatterSeries displayedMarkedPoints;
        private int pointsPerSec;
        private bool isDataIntialized = false;
        public VMDotsGraph(Model.IMGraph model, int pointsPerSec) : base(model)
        {
            xAxe = new LinearAxis() { Position = AxisPosition.Bottom};
            PlotModel.Axes.Add(xAxe);

            this.pointsPerSec = pointsPerSec;
        }

        public void SetGraphData(IList<Point> allPoints, IList<Point> allMarkedPoints, IList<Tuple<Func<double, double>, double, double>> regFuncs)
        {
            PlotModel.Series.Clear();

            this.allPoints = GetDataPointList(allPoints, allMarkedPoints);

            displayedPoints = new ScatterSeries()
            {
                ItemsSource = this.allPoints.GetRange(START_POINT_INDEX, START_POINT_INDEX),
                MarkerType = MarkerType.Circle,
                MarkerFill = OxyColors.Black
            };

            this.allMarkedPoints = GetMarkedPointList(allPoints, allMarkedPoints);

            displayedMarkedPoints = new ScatterSeries()
            {
                ItemsSource = this.allPoints.GetRange(START_POINT_INDEX, START_POINT_INDEX),
                MarkerType = MarkerType.Circle,
                MarkerFill = OxyColors.Red
            };

            PlotModel.Series.Add(displayedPoints);
            PlotModel.Series.Add(displayedMarkedPoints);

            SetRegressionFunc(regFuncs, getMaxVal(allPoints), getMinVal(allPoints));

            isDataIntialized = true;
            UpdateGraphPoints();
        }

        private double getMinVal(IList<Point> allPoints)
        {
            double min = 0;

            foreach(Point point in allPoints)
            {
                if (point.X < min)
                {
                    min = point.X;
                }
            }

            return min;
        }

        private double getMaxVal(IList<Point> allPoints)
        {
            double max = 0;

            foreach (Point point in allPoints)
            {
                if (point.X > max)
                {
                    max = point.X;
                }
            }

            return max;
        }

        private List<ScatterPoint> GetDataPointList(IList<Point> allPoints, IList<Point> allMarkedPoints)
        {
            List<ScatterPoint> scatterPoints = new List<ScatterPoint>();

            foreach (Point point in allPoints)
            {
                ScatterPoint scatterPoint = new ScatterPoint(point.X, point.Y);

                if (allMarkedPoints.Contains(point))
                {
                    scatterPoint.Size = 0;
                }

                scatterPoints.Add(scatterPoint);
            }

            return scatterPoints;
        }

        private List<ScatterPoint> GetMarkedPointList(IList<Point> allPoints, IList<Point> allMarkedPoints)
        {
            List<ScatterPoint> scatterPoints = new List<ScatterPoint>();

            foreach (Point point in allPoints)
            {
                ScatterPoint scatterPoint = new ScatterPoint(point.X, point.Y);

                if(!allMarkedPoints.Contains(point))
                {
                    scatterPoint.Size = 0;
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

            displayedPoints.ItemsSource = allPoints.GetRange(startIndex, numPointsToDisplay);
            displayedMarkedPoints.ItemsSource = allMarkedPoints.GetRange(startIndex, numPointsToDisplay);

            PlotModel.InvalidatePlot(true);
        }

        private void SetRegressionFunc(IList<Tuple<Func<double,double>, double, double>> regFuncs, double maxValue, double minValue)
        {
            foreach (var funcSeries in regFuncs)
            {
                Func<double, double> func = funcSeries.Item1;
                double start = funcSeries.Item2;
                double end = funcSeries.Item3;

                double x = func.Invoke(10);

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
