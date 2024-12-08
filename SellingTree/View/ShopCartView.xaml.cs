using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using SellingTree.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

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


        private void pay_Click(object sender, RoutedEventArgs e)
        {
            // tôi muốn thực hiện thanh toán bằng cách ghi vào database 1 order mới với tổng giá và ghi chi tiết các product vào detail
            // sau đó xóa hết các sản phẩm trong giỏ hàng
            ShopListViewModel.instance.Pay();

        }
    }
}
