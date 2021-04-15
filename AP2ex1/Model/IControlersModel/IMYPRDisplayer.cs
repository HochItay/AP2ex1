using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.Model
{
    /// <summary>
    /// this inteface is for the yaw pitch and roll part of the model.
    /// </summary>
    public interface IMYPRDisplayer : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the yaw value.
        /// </summary>
        int Yaw
        {
            get;
        }

        /// <summary>
        /// Gets the pitch value.
        /// </summary>
        int Pitch
        {
            get;
        }

        /// <summary>
        /// Gets the roll value.
        /// </summary>
        int Roll
        {
            get;
        }
    }
}
