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
    /// Interaction logic for PGetFiles.xaml
    /// </summary>
    public partial class PGetFiles : Page
    {
        public static readonly int HEIGHT = 300;
        public static readonly int WIDTH = 300;

        public delegate void switchFrame();
        public event switchFrame SwitchFrames;

        private framesViewModel.IVMPGetFiles getFilesVM;

        public PGetFiles()
        {   
            InitializeComponent();

            //getFilesVM = new framesViewModel.VMPGetFiles(new ...);

            BBrowseCsv.FilePath = constatnts.Paths.CSV_FILE_PATH;
            BBrowseCsv.notifyFileChanged += getFilesVM.FileDataChanged;

            BBrowseXml.FilePath = constatnts.Paths.XML_FILE_PATH;
            BBrowseXml.notifyFileChanged += getFilesVM.FileDataChanged;
        }

        private void SwitchAll(object sender, RoutedEventArgs e)
        {
            getFilesVM.FGPath = TBPath.Text;
            SwitchFrames();
        }
    }
}
