using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System;
namespace SellingTree
{
    public sealed partial class ShopCartView : Page
    {

        public ShopCartView()
        {
            InitializeComponent();
            DataContext = ShopListViewModel.instance;
        }


        private void ItemClear_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ShopListViewModel.instance.DeleteItem(button.Tag.ToString());
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ShopListViewModel.instance.ViewProduct((sender as Image).Tag.ToString());
        }

        private void PageChangerButton_Clicked(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button.Content.ToString() == "..." || button.Style == PageChanger.accentButtonStyle)
                return;
            ShopListViewModel.instance.ChangePage(button.Content as String);
        }
    }
}
