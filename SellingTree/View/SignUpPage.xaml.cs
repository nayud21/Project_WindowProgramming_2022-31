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
using Windows.Foundation;
using Windows.Foundation.Collections;
using SellingTree.IDao;
using SellingTree.Model;
using System.Threading.Tasks;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SellingTree.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            this.InitializeComponent();
        }

        private async void regisButton_Click(object sender, RoutedEventArgs e)
        {
            PostgreDaoUser postgreDaoUser = new PostgreDaoUser();
            string password = passwordBox.Password;
            string againPassword = againpasswordBox.Password;
            if (password != againPassword)
            {
                errorTextBlock.Text = "Password not match";
                return;
            }

            postgreDaoUser.InsertUser(new User
            {
                Name = nameTextBox.Text,
                Username = usernameTextBox.Text,
                Password = passwordBox.Password,
                Type = "user",
                ImageLocation = "customer-avatar.png"
            } );
            await ShowSuccessDialog();
            this.Frame.Navigate(typeof(LoginPage));
        }
        private async Task ShowSuccessDialog()
        {
            ContentDialog successDialog = new ContentDialog
            {
                Title = "Registration Successful",
                Content = "Your account has been created successfully.",
                CloseButtonText = "OK",
                XamlRoot = this.Content.XamlRoot
            };

            await successDialog.ShowAsync();
        }
    }
}
