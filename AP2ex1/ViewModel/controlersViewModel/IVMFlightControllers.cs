using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.ViewModel
{
    /// <summary>
    /// This is the VM for the Flight Controllers.
    /// It has the throttle, aileron, elevator and  ruddel.
    /// properties. all of the properties has only getters because only the model can change them.
    /// the vm implement the INotifyPropertyChanged in order to notify the view when the values are changing.
    /// </summary>
    public interface IVMFlightControllers : INotifyPropertyChanged
    {
        /// <summary>
        /// this is the throttle of the plane.
        /// </summary>
        public double VM_Throttle
        {
            get;
        }
        /// <summary>
        /// this is the aileron of the plane.
        /// </summary>
        public double VM_Aileron
        {
            get;
        }
        /// <summary>
        /// this is the elevator of the plane.
        /// </summary>
        public double VM_Elevator
        {
            get;
        }
        /// <summary>
        /// this is the rudder of the plane.
        /// </summary>
        public double VM_Rudder
        {
            get;
        }
    }
}
