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
    class VMLinesGraph: AVMGraph
    {
        private List<DataPoint> allPoints;
        private LineSeries displayedPoints;
        private bool isDataIntialized = false;

        public VMLinesGraph(Model.IMGraph model) : base(model)
        {
            xAxe = new TimeSpanAxis() { Position = AxisPosition.Bottom, StringFormat = "mm:ss"};
            PlotModel.Axes.Add(xAxe);

        }

        public void SetGraphData(IList<Point> allPoints)
        {
            PlotModel.Series.Clear();

            this.allPoints = GetDataPointList(allPoints);
            displayedPoints = new LineSeries() {ItemsSource = this.allPoints.GetRange(START_POINT_INDEX, START_POINT_INDEX)};

            PlotModel.Series.Add(displayedPoints);

            isDataIntialized = true;
            UpdateGraphPoints();
        }
        private List<DataPoint> GetDataPointList(IList<Point> allPoints)
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            foreach(Point point in allPoints)
            {
                dataPoints.Add(new DataPoint(point.X, point.Y));
            }

            return dataPoints;
        }

        public override void UpdateGraphPoints()
        {
            if (!isDataIntialized)
            {
                return;
            }

            displayedPoints.ItemsSource = allPoints.GetRange(START_POINT_INDEX, VM_CurrentLine);
            PlotModel.InvalidatePlot(true);
        }
    }
}
