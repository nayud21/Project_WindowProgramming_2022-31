using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTree
{
    class IntToVNDIConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            String result = value as String;
            return ((int)value).ToString("N0") + "đ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
