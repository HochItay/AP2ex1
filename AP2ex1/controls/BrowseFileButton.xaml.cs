using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace AP2ex1.controls
{
    /// <summary>
    /// Interaction logic for BrowseButton.xaml
    /// </summary>
    public partial class BrowseFileButton : UserControl
    {
        private readonly string DIR_PATH = "dataFiles";

        private string text = "Brawse File";
        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
            }
        }

        private string filter;
        public string Filter
        {
            get
            {
                return filter;
            }

            set
            {
                filter = value;
            }
        }

        private string fileName;
        public string FileName
        {
            get
            {
                return fileName;
            }

            set
            {
                fileName = value;
            }
        }

        public BrowseFileButton()
        {
            InitializeComponent();
        }

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!Directory.Exists(DIR_PATH))
                {
                    Directory.CreateDirectory(DIR_PATH);
                }

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = filter;
                if (openFileDialog.ShowDialog() == true)
                {
                    File.Copy(openFileDialog.FileName, DIR_PATH + "/" + fileName, true);
                }
            }
            catch
            {
                //Got Exeption
            }
        }
    }
}
