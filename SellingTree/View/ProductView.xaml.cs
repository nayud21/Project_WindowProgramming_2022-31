using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using SellingTree.Model;
using System;
using System.Collections.Generic;

namespace SellingTree
{
    public sealed partial class ProductView : Page
    {
        Product Product;
        public ProductView(Product product)
        {
            InitializeComponent();

            DataContext = new Reviews(product, IDao.MockDaoCollection.GetAllReviews(product));
            Product = product;

        }

        private void ShopList_Added(object sender, RoutedEventArgs e)
        {
            var quantity = QuantityBox.Value.ToString();
            ShopListViewModel.instance.Add(Product, int.Parse(quantity));
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
