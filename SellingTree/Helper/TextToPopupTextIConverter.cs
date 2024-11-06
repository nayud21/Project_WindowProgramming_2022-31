using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTree
{
    class TextToPopupTextConverter : IValueConverter
    {
        const int MaxCharacter = 150;
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            String result = value as String;
            if (result.Length < MaxCharacter)
                return result;
            result = result.Substring(0, MaxCharacter);
            int index = result.LastIndexOf(' ');
            return result.Substring(0,index) + "...";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
