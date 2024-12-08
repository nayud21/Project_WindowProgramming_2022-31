using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

namespace SellingTree
{
    class IntToVisibilityIConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (int.Parse(value.ToString()) == 0)? 1 : 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
