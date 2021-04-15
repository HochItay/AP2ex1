using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.Model
{

    /// <summary>
    /// this interface is for the flight controllers model.
    /// </summary>
    public interface IMFlightControllers : INotifyPropertyChanged
    {
        /// <summary>
        /// the throttle's value.
        /// </summary>
        public double Throttle
        {
            get;
        }

        /// <summary>
        /// the aileron's value.
        /// </summary>
        public double Aileron
        {
            get;
        }

        /// <summary>
        /// the elevator's value.
        /// </summary>
        public double Elevator
        {
            get;
        }

        /// <summary>
        /// the rudder's value.
        /// </summary>
        public double Rudder
        {
            get;
        }
    }
}
