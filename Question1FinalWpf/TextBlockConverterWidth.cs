using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Question1FinalWpf
{

   public class TextBlockConverterWidth : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((double)value <= 135)
            {
                return "Small".ToString();
            }
            else if ((double)value >= 135 && (double)value <= 160)
            {
                return "Medium".ToString();
            }
            else if ((double)value >= 160 && (double)value <= 185)
            {
                return "Large".ToString();
            }
            else
                return "Extra Large".ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
