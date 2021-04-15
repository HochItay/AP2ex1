using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.ViewModel
{
    /// <summary>
    /// This is the VM for the yaw pitch roll displayer.
    /// It has the yaw pitch and roll.
    /// properties. all of the properties has only getters because only the model can change them.
    /// the vm implement the INotifyPropertyChanged in order to notify the view when the values are changing.
    /// </summary>
    public interface IVMYPRDisplayer : INotifyPropertyChanged
    {
        /// <summary>
        /// this is the yaw of the plane.
        /// </summary>
        int VM_Yaw
        {
            get;
        }
        /// <summary>
        /// this is the roll of the plane.
        /// </summary>
        int VM_Pitch
        {
            get;
        }
        /// <summary>
        /// this is the pitch of the plane.
        /// </summary>
        int VM_Roll
        {
            get;
        }
    }
}
