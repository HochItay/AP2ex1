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
    /// Interaction logic for BrowseButton.xaml
    /// </summary>
    public partial class BrowseButton : UserControl
    {
        public delegate void whatToDo();
        public event whatToDo notifyAll;
        public BrowseButton()
        {
            InitializeComponent();
        }

        /// <summary>
        /// does what is requried on pressed.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the data</param>
        private void BrawseFiles(object sender, RoutedEventArgs e)
        {
            notifyAll();
        }
    }
}
