using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.Model
{
    public partial class FlightModel : IFlightModel
    {
        private readonly string[] properties =  { "hi" };

        private void NotifyChanges()
        {
            foreach (string prop in properties)
            {
                NotifyPropertyChanged(prop);
            }
        }
    }
}
