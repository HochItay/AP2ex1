using AP2ex1.controlersViewModel;
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

namespace AP2ex1.controls
{
    /// <summary>
    /// Interaction logic for Altimeter.xaml
    /// </summary>
    public partial class Altimeter : UserControl
    {
        IVMFlightData vm;
        public Altimeter()
        {
            InitializeComponent();
            //vm = new VMFlightData();
            DataContext = vm;
        }
    }
}
