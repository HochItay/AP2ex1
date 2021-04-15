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
    /// <summary>
    /// This class represents the anomaly graph.
    /// </summary>
    class VMDotsGraph: AVMGraph
    {
        private static readonly int LAST_SECS_TO_DISPLAY = 30;
        private List<ScatterPoint> allPoints;
        private ScatterSeries displayedPoints;
        private List<ScatterPoint> allMarkedPoints;
        private ScatterSeries displayedMarkedPoints;
        private int pointsPerSec;
        private bool isDataIntialized = false;

        /// <summary>
        /// Costructor to create the graph.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="pointsPerSec"></param>
        public VMDotsGraph(Model.IMGraph model, int pointsPerSec) : base(model)
        {
            //Ading the X Axe
            xAxe = new LinearAxis() { Position = AxisPosition.Bottom};
            PlotModel.Axes.Add(xAxe);

            this.pointsPerSec = pointsPerSec;
        }

        /// <summary>
        /// Sets the graphs data (should be used when var to display is changed)
        /// </summary>
        /// <param name="allPoints">all the points in the graphs</param>
        /// <param name="allMarkedPoints">all the anomaly points in the graph</param>
        /// <param name="regFuncs">the funcs that represents the graph to investigate.</param>
        public void SetGraphData(IList<Point> allPoints, IList<Point> allMarkedPoints, IList<Tuple<Func<double, double>, double, double>> regFuncs)
        {
            //clears the displayed data
            PlotModel.Series.Clear();

            //gets the all the points that aren't anomaly.
            this.allPoints = GetDataPointList(allPoints, allMarkedPoints);

            //set the displayer object of those points.
            displayedPoints = new ScatterSeries()
            {
                ItemsSource = this.allPoints.GetRange(START_POINT_INDEX, START_POINT_INDEX),
                MarkerType = MarkerType.Circle,
                MarkerFill = OxyColors.Black
            };

            //gets the anomaly points 
            this.allMarkedPoints = GetMarkedPointList(allPoints, allMarkedPoints);

            //set the displayer object of those points.
            displayedMarkedPoints = new ScatterSeries()
            {
                ItemsSource = this.allPoints.GetRange(START_POINT_INDEX, START_POINT_INDEX),
                MarkerType = MarkerType.Circle,
                MarkerFill = OxyColors.Red
            };


            //adding the displayers
            PlotModel.Series.Add(displayedPoints);
            PlotModel.Series.Add(displayedMarkedPoints);

            //adding the graph to investigate
            SetRegressionFunc(regFuncs, getMaxVal(allPoints), getMinVal(allPoints));

            //only in the first set we should run the thread to update.
            if(!isDataIntialized)
            {
                thread.Start();
                isDataIntialized = true;
            }
        }

        /// <summary>
        /// Gets the min x value from the points
        /// </summary>
        /// <param name="allPoints">the points to get the min from</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the max x value from the points
        /// </summary>
        /// <param name="allPoints">the points to get the max from</param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns the list of the points which aren't anomaly.
        /// </summary>
        /// <param name="allPoints">all the point</param>
        /// <param name="allMarkedPoints">the anomaly points</param>
        /// <returns>returns the list of the points which aren't anomaly.</returns>
        private List<ScatterPoint> GetDataPointList(IList<Point> allPoints, IList<Point> allMarkedPoints)
        {
            List<ScatterPoint> scatterPoints = new List<ScatterPoint>();

            foreach (Point point in allPoints)
            {
                ScatterPoint scatterPoint = new ScatterPoint(point.X, point.Y);

                //if point is an anomaly one she should not be seen in this sereies.
                if (allMarkedPoints.Contains(point))
                {
                    scatterPoint.Size = 0;
                }

                scatterPoints.Add(scatterPoint);
            }

            return scatterPoints;
        }


        /// <summary>
        /// Returns the list of the points which are anomaly.
        /// </summary>
        /// <param name="allPoints">all the point</param>
        /// <param name="allMarkedPoints">the anomaly points</param>
        /// <returns>returns the list of the points which are anomaly</returns>
        private List<ScatterPoint> GetMarkedPointList(IList<Point> allPoints, IList<Point> allMarkedPoints)
        {
            List<ScatterPoint> scatterPoints = new List<ScatterPoint>();

            foreach (Point point in allPoints)
            {
                ScatterPoint scatterPoint = new ScatterPoint(point.X, point.Y);

                //if point isn't an anomaly one she should not be seen in this sereies.
                if (!allMarkedPoints.Contains(point))
                {
                    scatterPoint.Size = 0;
                }

                scatterPoints.Add(scatterPoint);
            }

            return scatterPoints;
        }

        /// <summary>
        /// updates the graphs data, to show only 
        /// the dots in the last LAST_SECS_TO_DISPLAY sec.
        /// </summary>
        public override void UpdateGraphPoints()
        {   
            //if data isn't intialized should not update.
            if(!isDataIntialized)
            {
                return;
            }

            // calculate the start point to display
            // and the num of points that should be displayed
            int numPointsToDisplay = LAST_SECS_TO_DISPLAY * pointsPerSec;
            int startIndex = VM_CurrentLine - numPointsToDisplay;
            if (startIndex < 0)
            {
                startIndex = 0;
                numPointsToDisplay = VM_CurrentLine;
            }

            //updating the graph
            displayedPoints.ItemsSource = allPoints.GetRange(startIndex, numPointsToDisplay);
            displayedMarkedPoints.ItemsSource = allMarkedPoints.GetRange(startIndex, numPointsToDisplay);
            PlotModel.InvalidatePlot(true);
        }

        /// <summary>
        /// Sets the graph that should be investigated.
        /// </summary>
        /// <param name="regFuncs">the funcs that should represents the graph</param>
        /// <param name="maxValue">the max value X point</param>
        /// <param name="minValue">the min value Y point</param>
        private void SetRegressionFunc(IList<Tuple<Func<double,double>, double, double>> regFuncs, double maxValue, double minValue)
        {
            //for each func that assembles the graph:
            foreach (var funcSeries in regFuncs)
            {
                //gets the func and its domain
                Func<double, double> func = funcSeries.Item1;
                double start = funcSeries.Item2;
                double end = funcSeries.Item3;

                //handels special domains
                if(Double.IsInfinity(start))
                {
                    start = minValue;
                }
                if (Double.IsInfinity(end))
                {
                    end = maxValue;
                }

                //adds the func in her domain
                PlotModel.Series.Add(new FunctionSeries(func, start, end, 0.0001));
            }
        }
    }
}
