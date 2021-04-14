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
            //vm = new VMMediaController();
            InitializeComponent();
        }

        private void BFastBackward_Click(object sender, RoutedEventArgs e)
        {
            vm.StartOver();
        }

        private void BFastForward_Click(object sender, RoutedEventArgs e)
        {
            vm.GoToEnd();
        }

        private void BTenForward_Click(object sender, RoutedEventArgs e)
        {
            vm.SkipTen();
        }

        private void BTenBackward_Click(object sender, RoutedEventArgs e)
        {
            vm.GoBackTen();
        }

        private void BPlay_Click(object sender, RoutedEventArgs e)
        {
            vm.PlayClicked();
        }
    }
}
