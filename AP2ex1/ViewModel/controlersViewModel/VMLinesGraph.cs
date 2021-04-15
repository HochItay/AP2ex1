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
    /// represents graph that conects dots with lines
    /// </summary>
    class VMLinesGraph: AVMGraph
    {
        private List<DataPoint> allPoints;
        private LineSeries displayedPoints;
        private bool isDataIntialized = false;

        /// <summary>
        /// Constructor for this graph type.
        /// </summary>
        /// <param name="model">the model to get the data from</param>
        public VMLinesGraph(Model.IMGraph model) : base(model)
        {
            //sets the X Axe
            xAxe = new TimeSpanAxis() { Position = AxisPosition.Bottom, StringFormat = "mm:ss"};
            PlotModel.Axes.Add(xAxe);
        }

        /// <summary>
        /// Sets the graph's data
        /// </summary>
        /// <param name="allPoints">all the point that in the graph</param>
        public void SetGraphData(IList<Point> allPoints)
        {
            //clear the graph
            PlotModel.Series.Clear();

            //adds the sereis of the displayed points on the graph
            this.allPoints = GetDataPointList(allPoints);
            displayedPoints = new LineSeries() {ItemsSource = this.allPoints.GetRange(START_POINT_INDEX, START_POINT_INDEX)};
            PlotModel.Series.Add(displayedPoints);

            //only the first time the graph is set we should start the update thread
            if (!isDataIntialized)
            {
                thread.Start();
                isDataIntialized = true;
            }
        }

        /// <summary>
        /// Gets the point in the right object
        /// </summary>
        /// <param name="allPoints">all the graphs points</param>
        /// <returns></returns>
        private List<DataPoint> GetDataPointList(IList<Point> allPoints)
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            foreach(Point point in allPoints)
            {
                //convert all point to type of DataPoint
                dataPoints.Add(new DataPoint(point.X, point.Y));
            }

            return dataPoints;
        }

        /// <summary>
        /// updates the graphs points.
        /// </summary>
        public override void UpdateGraphPoints()
        {
            //if the graph isn't intialized shouldn't update.
            if (!isDataIntialized)
            {
                return;
            }

            //Updates the points to display.
            displayedPoints.ItemsSource = allPoints.GetRange(START_POINT_INDEX, VM_CurrentLine);
            PlotModel.InvalidatePlot(true);
        }
    }
}
