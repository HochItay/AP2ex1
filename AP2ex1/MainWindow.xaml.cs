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
        private frames.PSimulator pSimulator;
        private frames.PGetFiles pGetFiles;

        public MainWindow()
        {
            InitializeComponent();

            pSimulator = new frames.PSimulator();
            pSimulator.notifyAll += SwitchFrames;

            pGetFiles = new frames.PGetFiles();

            Display.Content = pSimulator;
        }

        void SwitchFrames()
        {
            if(Display.Content == pSimulator)
            {
                Display.Content = pGetFiles;
                return;
            }

            Display.Content = pSimulator;
        }
    }
}
