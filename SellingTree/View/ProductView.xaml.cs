using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SellingTree
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductView : Page
    {
        Model.Product Product;
        List <Image> ImageList = new List<Image> ();
        public ProductView(Model.Product product)
        {
            this.InitializeComponent();
            DataContext = Product = product;
            
        }

        private void ShopList_Added(object sender, RoutedEventArgs e)
        {
            var quantity = QuantityBox.Value.ToString();
            ShopListViewModel.instance.Add(Product, int.Parse(quantity));
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            ImageList.Add(sender as Image);
        }

        private void OnPointerEntered(object sender, PointerRoutedEventArgs e)
        {
            var BImage = (sender as Image).Source as BitmapImage;
            MainImage.Source = new BitmapImage(new Uri(BImage.UriSource.ToString()));
        }

        private void OnPointerExited(object sender, PointerRoutedEventArgs e)
        {
            MainImage.Source = new BitmapImage(new Uri(Product.ImageSource));
        }
    }
}
