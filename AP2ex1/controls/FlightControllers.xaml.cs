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
    /// Interaction logic for FlightControllers.xaml
    /// </summary>
    public partial class FlightControllers : UserControl
    {
        private VMSlider initVM()
        {
            VMSlider vm = new VMSlider();
            vm.VM_Value = 0.5;
            vm.VM_Maximum = 1;
            vm.VM_Minimum = -1;
            return vm;
        }
        private VMSlider vmAileron, vmRuddel, vmThrottle, vmElevator;
        public FlightControllers()
        {
            InitializeComponent();
            vmAileron = initVM();
            vmThrottle = initVM();
            vmElevator = initVM();
            vmRuddel = initVM();
            vmThrottle.VM_Minimum = 0;
            SAileron.VM = vmAileron;
            SElevetor.VM = vmElevator;
            SThrottle.VM = vmThrottle;
            SRuddel.VM = vmRuddel;
            
        }
    }
}
