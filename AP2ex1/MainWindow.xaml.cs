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
using System.Windows.Shapes;

namespace AP2ex1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly int WIN_CONTROLLERS_HEIGHT = 40;

        private ViewModel.IVMMain vmMain;

        private View.PSimulator pSimulator;
        private View.PGetFiles pGetFiles;
        public MainWindow()
        {
            InitializeComponent();

            vmMain = new ViewModel.VMMain(new Model.FlightModel());

            pSimulator = new View.PSimulator(vmMain.GetVMPSimulator());
            pSimulator.SwitchFrames += SwitchFrames;

            pGetFiles = new View.PGetFiles(vmMain.GetVMPGetFiles());
            pGetFiles.SwitchFrames += SwitchFrames;

            Display.Content = pSimulator;
        }

        void SwitchFrames()
        {
            if(Display.Content == pSimulator)
            {
                Display.Content = pGetFiles;
                WMain.Height = View.PGetFiles.HEIGHT + WIN_CONTROLLERS_HEIGHT;
                WMain.Width = View.PGetFiles.WIDTH;
                return;
            }

            Display.Content = pSimulator;
            WMain.Height = View.PSimulator.HEIGHT + WIN_CONTROLLERS_HEIGHT;
            WMain.Width = View.PSimulator.WIDTH;
        }
    }
}
