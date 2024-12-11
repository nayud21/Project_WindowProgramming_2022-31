using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using SellingTree.IDao;
using SellingTree.Model;
using System;
using System.Collections.Generic;
using Windows.Services.Store;

namespace SellingTree
{
    public sealed partial class ProductView : Page
    {
        Product Product;
        Reviews reviews;
        public ProductView(Product product)
        {
            InitializeComponent();
            reviews = new Reviews(product, IDao.PostgreDaoCollection.GetAllReviews(product));
            DataContext = reviews;
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

        private void NewReview_Clicked(object sender, RoutedEventArgs e)
        {
            if (SessionManager.CurrentUser == null)
            {

                errorTextBox.Text = "Bạn hãy đăng nhập để đánh giá!";
                return;
            }else 
                foreach (var review in reviews.ItemsData)
                {
                    if (review.user.Name == SessionManager.CurrentUser.Name)
                    {
                        errorTextBox.Text = "Bạn đã đánh giá rồi!";
                        return;
                    }
                }
            MainWindow.Instance.SetFrame(typeof(ReviewsAndPayBack), Product, float.Parse(reviews.AverageScore));

        }
    }
}
