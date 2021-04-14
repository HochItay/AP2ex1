using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.controlersViewModel
{
    public class VMSlider
    {
        double max=100, min=0, val=50;
        public double VM_Maximum
        {
            get
            {
                return max;
            }
            set
            {
                max = value;
            }
        }
        public double VM_Minimum
        {
            get
            {
                return min;
            }
            set
            {
                min = value;
            }
        }
        public double VM_Value
        {
            get
            {
                return val;
            }
            set
            {
                val = value;
            }
        }
    }
}
