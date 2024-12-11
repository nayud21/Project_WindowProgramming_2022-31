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
using System.Diagnostics;
using Microsoft.UI.Xaml.Media.Imaging;
using SellingTree.IDao;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SellingTree
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NavigationBarView : Page
    {
        public static NavigationBarView instance;
        public PostgreDaoUser _postgreDaoUser;
        public NavigationBarView()
        {
            this.InitializeComponent();
            DataContext = ShopListViewModel.instance;

            instance = this;
            _postgreDaoUser = new PostgreDaoUser();

        }

        private void ShopListButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (!SessionManager.IsLoggedIn() || SessionManager.CurrentUser.Type == "user")
            {

                MainWindow.Instance.SetFrame(typeof(ShopCartView));
                //ShopListButton.IsEnabled = false;
                //ShopListButton.Visibility = Visibility.Collapsed;

            }
            else
            {
                MainWindow.Instance.SetFrame(typeof(ShopCartAdminView));
            }
        }

        private void MainPageButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.SetFrame(typeof(MainView));
            ShopListButton.IsEnabled = true;
            ShopListButton.Visibility = Visibility.Visible;
        }

        private void blogButton_Click(object sender, RoutedEventArgs e)
        {
            if (SessionManager.IsLoggedIn())
            {
                if (SessionManager.IsAdmin())
                    MainWindow.Instance.SetFrame(typeof(BlogPageAdmin));
                else
                    MainWindow.Instance.SetFrame(typeof(BlogPage));
            }
            else
            MainWindow.Instance.SetFrame(typeof(BlogPage));
        }

        private void chatButton_Click(object sender, RoutedEventArgs e)
        {
            if (SessionManager.IsLoggedIn())
            {
                if (SessionManager.IsAdmin())
                {
                    MainWindow.Instance.SetFrame(typeof(ChatPage));
                }
                else
                    MainWindow.Instance.SetFrame(typeof(ChatPageCus));
            }
            else
            {
                MainWindow.Instance.SetFrame(typeof(LoginPage));
            }
        }

        private void collectionButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Collection Button Clicked");
            MainWindow.Instance.SetFrame(typeof(CollectionPage));
            // ShopListButton.IsEnabled = false;
            //ShopListButton.Visibility = Visibility.Visible;
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

        private void dictionaryButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.SetFrame(typeof(DictionaryPage));
        }

        public void setUser(User user)
        {
            UserDropDown.Visibility = Visibility.Visible;
            accountButton.Visibility = Visibility.Collapsed;
            UserName.Text = user.Name;
            //userImage.ProfilePicture = new BitmapImage(new Uri(user.ImageLocation));
        }

        private void accountPage_Click(object sender, RoutedEventArgs e)
        {
            if (!SessionManager.IsAdmin())
                MainWindow.Instance.SetFrame(typeof(AccountPage));
            else
                MainWindow.Instance.SetFrame(typeof(AccountPageAdmin));
        }

        public void logOut_Click(object sender, RoutedEventArgs e)
        {
            if (SessionManager.CurrentUser != null)
            {
                _postgreDaoUser.Logout(SessionManager.CurrentUser.UserId);
                SessionManager.Logout();
            }
            UserDropDown.Visibility = Visibility.Collapsed;
            accountButton.Visibility = Visibility.Visible;



           
        }
        private void moreOption_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.SetFrame(typeof(MoreOptionPage));

        }
    } 
}
