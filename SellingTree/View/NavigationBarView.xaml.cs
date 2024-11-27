using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SellingTree.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using SellingTree.Model;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SellingTree
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NavigationBarView : Page
    {
        public NavigationBarView()
        {
            this.InitializeComponent();
            DataContext = ShopListViewModel.instance;
        }

        private void ShopListButton_Clicked(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.SetFrame(typeof(ShopCartView));
            ShopListButton.IsEnabled = false;
            ShopListButton.Visibility = Visibility.Collapsed;
        }

        private void MainPageButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.SetFrame(typeof(MainView));
            ShopListButton.IsEnabled = true;
            ShopListButton.Visibility = Visibility.Visible;
        }

        private void blogButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.SetFrame(typeof(BlogPage));
            ShopListButton.IsEnabled = false;
            ShopListButton.Visibility = Visibility.Visible;
        }

        private void chatButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.SetFrame(typeof(ChatPage));
            ShopListButton.IsEnabled = false;
            ShopListButton.Visibility = Visibility.Visible;
        }

        private void collectionButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.SetFrame(typeof(CollectionPage));
            ShopListButton.IsEnabled = false;
            ShopListButton.Visibility = Visibility.Visible;
        }

        private void accountButton_Click(object sender, RoutedEventArgs e)
        {
            if (SessionManager.IsLoggedIn())
            {
                MainWindow.Instance.SetFrame(typeof(AccountPage));
            }
            else
            {
                MainWindow.Instance.SetFrame(typeof(LoginPage));
                //ShopListButton.IsEnabled = false;
                //ShopListButton.Visibility = Visibility.Visible;
            }
        }
    }
}
