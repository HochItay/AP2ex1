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

namespace AP2ex1.View
{
    /// <summary>
    /// Interaction logic for BrowseButton.xaml
    /// </summary>
    public partial class BrowseFileButton : UserControl
    {   
        public delegate void whatToDo(string fiilePath);
        public event whatToDo notifyFileChanged;

        /// <summary>
        /// the text of the button
        /// </summary>
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

        /// <summary>
        /// the filter of the load (when loading a file)
        /// </summary>
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

        public BrowseFileButton()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the needed file
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the data</param>
        private void SaveFile(object sender, RoutedEventArgs e)
        {
            try
            {
                //open a dialog to load the file
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = filter;
                if (openFileDialog.ShowDialog() == true)
                {
                    //loads the chosen file
                    notifyFileChanged(openFileDialog.FileName);
                }
            }
            catch
            {
                //if error on opening the dialog occurs notiffies the user.
                MessageBox.Show("Error in opning file dialog please try again", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
