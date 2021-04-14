using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.Model
{
    public interface IMYPRDisplayer
    {
        int Yaw
        {
            get;
        }
        int Pitch
        {
            get;
        }
        int Roll
        {
            get;
        }
    }
}
