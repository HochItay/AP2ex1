using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AP2ex1.Model
{
    /// <summary>
    /// this interfase is for the graph model.
    /// </summary>
    public interface IMGraphController : IMGraph
    {
        /// <summary>
        /// the names of the vars that can be investigated.
        /// </summary>
        IList<string> VarsNames
        {
            get;
        }

        /// <summary>
        /// Gets the num of points in the graph per sec,
        /// this is a constant that is determined by the speed of X1.
        /// </summary>
        /// <returns>the num of points in the graph per sec</returns>
        int GetNumPointsPerSec();

        /// <summary>
        /// Gets the corralative var.
        /// </summary>
        /// <param name="var"> the var to get his correlative var</param>
        /// <returns>the corralative var</returns>
        string GetCorrelativeVar(string var);

        /// <summary>
        /// Gets the point list of the var to display in the graph.
        /// </summary>
        /// <param name="var">the var to get</param>
        /// <returns>the point list of the var to display in the graph.</returns>
        IList<Point> GetVarPoints(string var);

        /// <summary>
        /// Returns the data for the anomaly graph,
        /// 0) all the points in the graph
        /// 1)1. the time of the anomaly point
        ///   2. the anomaly point
        /// </summary>
        /// <param name="var">the var to get the data for</param>
        /// <param name="corrilativeVar">the corrilative var to get the data for</param>
        /// <returns>the data for the anomaly graph</returns>
        Tuple<IList<Point>, IList<Tuple<TimeSpan, Point>>> GetAnomalyGraphPoints(string var, string corrilativeVar);

        /// <summary>
        /// Returns the graph to investigate:
        /// list of:
        /// 1)func to display
        /// 2+3) it's start and end => it's domain
        /// </summary>
        /// <param name="var">the anommaly graph var</param>
        /// <returns>the graph to investigate</returns>
        IList<Tuple<Func<double, double>, double, double>> GetGraphFuncs(string var);
    }
}
