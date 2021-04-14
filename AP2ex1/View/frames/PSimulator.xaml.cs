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
    /// Interaction logic for PSimulator.xaml
    /// </summary>
    public partial class PSimulator : Page
    {
        public static readonly int HEIGHT = 400;
        public static readonly int WIDTH = 800;

        public delegate void switchFrame();
        public event switchFrame SwitchFrames;

        private ViewModel.IVMPSimulator vmPSimulator;

        public PSimulator(ViewModel.IVMPSimulator vmPSimulator)
        {
            InitializeComponent();
            BSwitchFrame.notifyAll += SwitchAll;

            this.vmPSimulator = vmPSimulator;
            DataContext = this.vmPSimulator;

            graphController.VM = this.vmPSimulator.GetVMGraphController();
            mediaController.VM = this.vmPSimulator.GetVMMediaController();
            airspeedIndicator.VM = this.vmPSimulator.GetVMFlightData();
            altimeter.VM = this.vmPSimulator.GetVMFlightData();
            compass.VM = this.vmPSimulator.GetVMFlightData();
            flightControllers.VM = this.vmPSimulator.GetVMFlightControllers();
            joystick.VM = this.vmPSimulator.GetVMFlightData();
            yprDisplayer.VM = this.vmPSimulator.GetVMYPRDisplayer();
        }

        private void SwitchAll()
        {
            SwitchFrames();
        }
    }
}
