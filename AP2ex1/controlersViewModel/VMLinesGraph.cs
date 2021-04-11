﻿using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.controlersViewModel
{
    class VMLinesGraph: VMGraph
    {
        private IList<DataPoint> points;

        public VMLinesGraph()
        {
            var dateAxis = new TimeSpanAxis() { Position = AxisPosition.Bottom, StringFormat = "mm:ss" };
            PlotModel.Axes.Add(dateAxis);
        }

        public void setGraphData(IList<DataPoint> points)
        {
            PlotModel.Series.Clear();

            this.points = points;
          
            PlotModel.Series.Add(new LineSeries() { ItemsSource = this.points });
        }

        public void addPoints(IList<DataPoint> points)
        {
            foreach (DataPoint point in points)
            {
                this.points.Add(point);
            }

            PlotModel.InvalidatePlot(true);
        }
    }
}
