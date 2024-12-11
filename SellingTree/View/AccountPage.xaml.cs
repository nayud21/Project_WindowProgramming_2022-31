using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using SellingTree.IDao;
using SellingTree.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SellingTree.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountPage : Page
    {
        public AccountPage()
        {
            this.InitializeComponent();
            if (SessionManager.IsLoggedIn())
            {
                usernameTextBlock.Text = SessionManager.CurrentUser.Name;
                avatarImage.Source = new BitmapImage(new Uri(SessionManager.CurrentUser.ImageLocation));
                LoadOrders();
            }
        }
        private void LoadOrders()
        {
            IDaoOrder daoOrder = new PostgreDaoOrder();
            var orders = daoOrder.GetOrdersForCustomer(SessionManager.CurrentUser.UserId);
            
            ordersListView.ItemsSource = orders;
        }
        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationBarView.instance.logOut_Click(sender, e);

            // Navigate back to LoginPage
            this.Frame.Navigate(typeof(LoginPage));
        }
    }
}
