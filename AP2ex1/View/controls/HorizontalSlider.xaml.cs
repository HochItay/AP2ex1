using AP2ex1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AP2ex1.View
{
    /// <summary>
    /// Interaction logic for HorizontalSlider.xaml
    /// </summary>
    public partial class HorizontalSlider : UserControl
    {
        private double max, min, val;

        public HorizontalSlider()
        {
            InitializeComponent();
            DataContext = this;
        }
        public double Maximum
        {
            set
            {
                if (max != value)
                {
                    max = value;
                }
            }
            get
            {
                return max;
            }
        }
        public double Minimum
        {
            set
            {

                if (min != value)
                {
                    min = value;
                }
            }
            get
            {
                return min;
            }
        }
        public double Value
        {
            set
            {
                if (val != value)
                {
                    val = value;
                }
            }
            get
            {
                return val;
            }
        }
    }
}

