using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AP2ex1.View
{
    /// <summary>
    /// this is a converter class for the media controller.
    /// it get a bool (whether the video is running or not)
    /// and return the currect path of the image in order that the controller will displays it.
    /// </summary>
    public class IsRunningToImageConverter : IValueConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"> should be bool</param>
        /// <param name="targetType">not in use</param>
        /// <param name="parameter">not in use</param>
        /// <param name="culture">not in use</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return "images/IMediaController/play.png";
            }
            return "images/IMediaController/pause.png";
        }
        /// <summary>
        /// we didn't implement it because we don't convert back.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
