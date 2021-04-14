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

namespace AP2ex1.frames
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

        public PSimulator()
        {
            InitializeComponent();
            BSwitchFrame.notifyAll += SwitchAll;
        }

        private void SwitchAll()
        {
            SwitchFrames();
        }
    }
}
