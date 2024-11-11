using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http.Headers;

namespace SellingTree.Model
{
    public class ProductCollection : Product
    {

        public BitmapImage Image { get; set; }
        public String Meanings { get; set; }

    }
}
