using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace App4.Converter
{
    class ImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //var icon = (Icon)value;
            //var path = String.Empty;

            //switch (icon)
            //{
            //    case Icon.Sunny:
            //        path = "assets/sunny.png";
            //        break;
            //    case Icon.Cloudy:
            //        path = "assets/cloudy.png";
            //        break;
            //    case Icon.Rainy:
            //        path = "assets/rainy.png";
            //        break;
            //    case Icon.Snowy:
            //        path = "assets/snowy.png";
            //        break;
            //    default:
            //        break;
            //}
            //return path;
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
