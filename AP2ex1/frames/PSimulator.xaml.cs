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
        public delegate void whatToDo();
        public event whatToDo notifyAll;

        public PSimulator()
        {
            InitializeComponent();
            BSwitchFrame.notifyAll += NotifyAll;
        }

        private void NotifyAll()
        {
            notifyAll();
        }
    }
}
