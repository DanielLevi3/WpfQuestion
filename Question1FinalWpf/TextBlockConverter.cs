using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Question1FinalWpf
{
    public class TextBlockConverter : IValueConverter
    {
       
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((double)value <=54)
            {
                return value="Small".ToString();
            }
            else if ((double)value >=54 && (double)value <=79 )
            {
                return value="Medium".ToString();
            }
            else if ((double)value >= 79&& (double)value <=104 )
            {
                return "Large".ToString(); ;
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
