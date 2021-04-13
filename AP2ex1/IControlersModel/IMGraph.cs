using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.IControlersModel
{
    interface IMGraph : INotifyPropertyChanged
    {
        int CurrentLine{
            get;
            set;
        }
    }
}
