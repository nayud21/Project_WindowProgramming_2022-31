using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTree
{
    class QuantityToStringIConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int result = (int)value;

            if (result < 1000) 
                return result.ToString();


            char unit = ' ';
            double thisValue;
            if (result > 1000000000)
            {
                unit = 'T'; thisValue = (double)result / 1000000000;
            }
            else if (result > 1000000)
            {
                unit = 'm'; thisValue = (double)result / 1000000;
            }
            else
            {
                unit = 'k'; thisValue = (double)result / 1000;
            }

            return thisValue.ToString("F1") + unit;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
