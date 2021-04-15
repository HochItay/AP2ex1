using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2ex1.ViewModel
{
    /// <summary>
    /// the interface of the view model getfiles page.
    /// </summary>
    public interface IVMPGetFiles
    {
        /// <summary>
        /// files where loaded and should update.
        /// </summary>
        /// <param name="filePath">the file path that was loaded</param>
        void FileDataChanged(string filePath);
    }
}
