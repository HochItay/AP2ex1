using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PluginInterface
{
    public interface IAnomalyDetector
    {
        // learn from normal data
        void LearnNormal(string csvFile, List<string> features);

        // detect anomalies, return list of all anomalies
        // each anomaly is a tuple of <line, feature1, feature2>
        IList<Tuple<int, string, string>> DetectAnomalies(string csvFile);

        // return a graph that represent the anomaly alogithm
        // the graph is reresented by a function, starting cordinate and ending cordinate
        // we return list of this tuples to be able to draw non-function graphs such as circle
        public IList<Tuple<Func<double, double>, double, double>> GetGraph(string feature);

        // get correlated feture of a certain feture
        string GetCorrelatedFeature(string feature);
    }
}
