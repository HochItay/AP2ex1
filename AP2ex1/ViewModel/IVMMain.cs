using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.ViewModel
{
    public interface IVMMain
    {
        IVMPSimulator GetVMPSimulator();
        IVMPGetFiles GetVMPGetFiles();
    }
}
