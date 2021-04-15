using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.Model
{
    public interface IMGraph : INotifyPropertyChanged
    {
        /// <summary>
        /// the current line that is fed to the flight geer.
        /// </summary>
        int CurrentLine{
            get;
            set;
        }
    }
}
