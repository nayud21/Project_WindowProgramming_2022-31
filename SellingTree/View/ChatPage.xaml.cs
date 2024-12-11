using Microsoft.UI.Xaml.Controls;
using SellingTree.IDao;
using SellingTree.Model;
using SellingTree.ViewModel;
using System.Linq;

namespace SellingTree.View
{
    public sealed partial class ChatPage : Page
    {
        private readonly PostgreDaoMessage _daoMessage;
        public ChatPage()
        {
            this.InitializeComponent();
            _daoMessage = new PostgreDaoMessage();
        }

        private void OnCustomerSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedCustomer = (sender as ListView).SelectedItem as IGrouping<int, Message>;
            if (selectedCustomer != null)
            {
                var viewModel = DataContext as MessageViewModel;
                viewModel.LoadMessagesForCustomer(selectedCustomer.Key);
            }
        }

        private void OnSendButtonClick(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            // Xử lý khi nhấn nút "Gửi"
            var newMessage = new Message
            {
                Sender = "admin",
                Content = MessageInput.Text,
                Timestamp = System.DateTime.Now,
                CustomerID = (DataContext as MessageViewModel).SelectedCustomerMessages.FirstOrDefault().CustomerID,
                Name = "admin"
            };
            MessageInput.Text = string.Empty;

            // Save the message to the database
            _daoMessage.InsertMessage(newMessage);


        }
    }
}
