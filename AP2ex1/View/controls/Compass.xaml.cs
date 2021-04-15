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
    /// Interaction logic for Compass.xaml
    /// </summary>
    public partial class Compass : UserControl
    {
        private IVMFlightData vm;
        /// <summary>
        /// the vm of the Compass.
        /// </summary>
        public IVMFlightData VM
        {
            set
            {
                vm = value;
                DataContext = vm;
            }
        }
        /// <summary>
        /// init the compass.
        /// </summary>
        public Compass()
        {
            InitializeComponent();

        }
    }
}
