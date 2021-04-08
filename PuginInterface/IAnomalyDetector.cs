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
        void LearnNormal(string csvFile);

        // detect anomalies, return list of all lines with anomaly
        List<int> DetectAnomalies(string csvFile);

        //public something GetGraph(string feture);

        // get correlated feture of a certain feture
        string GetCorrelatedFeture(string feture);
    }
}
