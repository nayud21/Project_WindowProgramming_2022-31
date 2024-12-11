using Microsoft.UI.Xaml.Controls;
using SellingTree.ViewModel;
using SellingTree.Model;
namespace SellingTree.View
{
    public sealed partial class ChatPageCus : Page
    {
        private ChatPageCusViewModel _viewModel;

        public ChatPageCus()
        {
            this.InitializeComponent();
            _viewModel = (ChatPageCusViewModel)this.DataContext;
            _viewModel.SetCustomerId(SessionManager.CurrentUser.UserId); // Replace with the actual customer ID
        }

        private void OnSendButtonClick(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            _viewModel.SendMessage();
        }
    }
}
