using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTree
{
    class IntToVND2IConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            String result = value as String;
            return 'đ'+ ((int)value).ToString("#,0", new CultureInfo("de-DE"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
