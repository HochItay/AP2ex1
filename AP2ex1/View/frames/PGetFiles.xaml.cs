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
    /// Interaction logic for PGetFiles.xaml
    /// </summary>
    /// 
    public partial class PGetFiles : Page
    {
        //the difault size of this page
        public static readonly int HEIGHT = 300;
        public static readonly int WIDTH = 300;

        public delegate void switchFrame();
        public event switchFrame SwitchFrames;

        private ViewModel.IVMPGetFiles getFilesVM;

        /// <summary>
        /// The constructor of this class.
        /// </summary>
        /// <param name="getFilesVM">the vm to get data from</param>
        public PGetFiles(ViewModel.IVMPGetFiles getFilesVM)
        {   
            InitializeComponent();

            this.getFilesVM = getFilesVM;

            //adding functionality for the load buttons
            BBrowseCsv.notifyFileChanged += this.getFilesVM.FileDataChanged;
            BBrowseXml.notifyFileChanged += this.getFilesVM.FileDataChanged;
            BBrowseDll.notifyFileChanged += this.getFilesVM.FileDataChanged;
            BBrowseFG.notifyFileChanged += this.getFilesVM.FileDataChanged;
        }

        /// <summary>
        /// Switchs between the pages.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the data</param>
        private void SwitchAll(object sender, RoutedEventArgs e)
        {
            SwitchFrames();
        }
    }
}
