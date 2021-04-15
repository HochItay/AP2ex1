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
    /// Interaction logic for FlightControllers.xaml
    /// </summary>
    public partial class FlightControllers : UserControl
    {
        private IVMFlightControllers vm;
        /// <summary>
        /// the vm of the FlightControllers .
        /// </summary>
        public IVMFlightControllers VM
        {
            set
            {
                vm = value;
                DataContext = vm;
            }
        }
        /// <summary>
        /// init the FlightControllers.
        /// </summary>
        public FlightControllers()
        {
            InitializeComponent();
        }
    }
}
