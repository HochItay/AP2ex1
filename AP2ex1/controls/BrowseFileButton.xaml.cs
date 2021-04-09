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

namespace AP2ex1.controls
{
    /// <summary>
    /// Interaction logic for BrowseButton.xaml
    /// </summary>
    public partial class BrowseFileButton : UserControl
    {
        private string text = "Brawse File";
        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                if(text != value)
                {
                    text = value;
                }
            }
        }

        public BrowseFileButton()
        {
            InitializeComponent();
        }
    }
}
