using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.Model
{
    public interface IMFlightControllers : INotifyPropertyChanged
    {
        public double Throttle
        {
            get;
        }
        public double Aileron
        {
            get;
        }
        public double Elevetor
        {
            get;
        }
        public double Rudder
        {
            get;
        }
    }
}
