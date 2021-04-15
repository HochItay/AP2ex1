using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AP2ex1.Model
{
    public interface IMGraphController : IMGraph
    {
        IList<string> VarsNames
        {
            get;
        }
        int GetNumPointsPerSec();
        string GetCorrelativeVar(string var);
        IList<Point> GetVarPoints(string var);
        Tuple<IList<Point>, IList<Point>> GetAnomalyGraphPoints(string var, string corrilativeVar);
        IList<Tuple<Func<double, double>, double, double>> GetGraphFuncs(string var);
    }
}
