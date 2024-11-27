using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SellingTree.IDao;
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

namespace SellingTree.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private readonly PostgreDaoUser _postgreDaoUser;
        public LoginPage()
        {
            this.InitializeComponent();
            _postgreDaoUser = new PostgreDaoUser();
        }

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;

            var user = await _postgreDaoUser.ValidateUserAsync(username, password);

            if (user != null)
            {
                // Set the current user in the session manager
                SessionManager.Login(user);

                // Navigate to AccountPage
                this.Frame.Navigate(typeof(AccountPage));
            }
            else
            {
                // Show error message
            
            }
        }
    }
}
