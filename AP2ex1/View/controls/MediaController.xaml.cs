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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MediaController : UserControl
    {
        IVMMediaController vm;
        /// <summary>
        /// the vm of the MediaController.
        /// </summary>
        public IVMMediaController VM
        {
            set
            {
                vm = value;
                DataContext = vm;
            }
        }

        public MediaController()
        {
            InitializeComponent();
        }
        /// <summary>
        /// command the vm to execute startover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BFastBackward_Click(object sender, RoutedEventArgs e)
        {
            vm.StartOver();
        }
        /// <summary>
        /// command the vm to execute go to end
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BFastForward_Click(object sender, RoutedEventArgs e)
        {
            vm.GoToEnd();
        }
        /// <summary>
        /// command the vm to execute skip ten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTenForward_Click(object sender, RoutedEventArgs e)
        {
            vm.SkipTen();
        }
        /// <summary>
        /// command the vm to execute go back ten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTenBackward_Click(object sender, RoutedEventArgs e)
        {
            vm.GoBackTen();
        }
        /// <summary>
        /// command the vm to execute PlayClicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BPlay_Click(object sender, RoutedEventArgs e)
        {
            vm.PlayClicked();
        }
    }
}
