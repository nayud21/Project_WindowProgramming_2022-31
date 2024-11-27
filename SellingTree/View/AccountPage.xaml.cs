using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
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
                usernameTextBlock.Text = SessionManager.CurrentUser.Username + SessionManager.CurrentUser.UserId;
            }
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Logout the user
            SessionManager.Logout();

            // Navigate back to LoginPage
            this.Frame.Navigate(typeof(LoginPage));
        }
    }
}
