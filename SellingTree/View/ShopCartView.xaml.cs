using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SellingTree
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShopCartView : Page
    {

        public ShopCartView()
        {
            InitializeComponent();
            DataContext = ShopListViewModel.instance;

        }


        private void Data_Change(object sender, RoutedEventArgs e)
        {
            ShopListViewModel.instance.LoadData();
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

    }
}
