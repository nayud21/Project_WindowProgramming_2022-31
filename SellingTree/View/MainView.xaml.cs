using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using System;

namespace SellingTree
{
    public sealed partial class MainView : Page
    {
        public MainView()
        {
            MainViewViewModel.instance.Reset();
            InitializeComponent();
            DataContext = MainViewViewModel.instance;

        }

        private void Popup_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            MainViewViewModel.instance.Add(sender as Popup);
        }

        private void OnPointerEntered(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            MainViewViewModel.instance.OnPointEntered(sender as Image);
        }

        private void OnPointerExited(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            MainViewViewModel.instance.OnPointExited(sender as Image);
        }

        private void ButtonBuy_Clicked(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {

            String productName = (sender as Button).Tag.ToString();
            MainViewViewModel.instance.ButtonBuy_Clicked(productName);
        }

        private void Image_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            String productName = (sender as Image).Tag.ToString();
            MainViewViewModel.instance.OpenProduct(productName);
        }
    }
}
