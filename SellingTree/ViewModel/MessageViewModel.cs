using SellingTree.IDao;
using SellingTree.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SellingTree.ViewModel
{
    public class MessageViewModel : INotifyPropertyChanged
    {
        private readonly PostgreDaoMessage _daoMessage;
        private ObservableCollection<IGrouping<int, Message>> _messagesGroupedByCustomer;
        private ObservableCollection<Message> _selectedCustomerMessages;
        private string _newMessageContent;
        public ObservableCollection<IGrouping<int, Message>> MessagesGroupedByCustomer
        {
            get => _messagesGroupedByCustomer;
            set
            {
                _messagesGroupedByCustomer = value;
                OnPropertyChanged();
            }
        }
        public string NewMessageContent
        {
            get => _newMessageContent;
            set
            {
                _newMessageContent = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Message> SelectedCustomerMessages
        {
            get => _selectedCustomerMessages;
            set
            {
                _selectedCustomerMessages = value;
                OnPropertyChanged();
            }
        }

        public MessageViewModel()
        {
            _daoMessage = new PostgreDaoMessage();
            MessagesGroupedByCustomer = new ObservableCollection<IGrouping<int, Message>>();
            SelectedCustomerMessages = new ObservableCollection<Message>();
            LoadMessagesGroupedByCustomer();
        }

        private async void LoadMessagesGroupedByCustomer()
        {
            var messages = await Task.Run(() => _daoMessage.GetMessages());
            var groupedMessages = messages.GroupBy(m => m.CustomerID);
            MessagesGroupedByCustomer = new ObservableCollection<IGrouping<int, Message>>(groupedMessages);
        }

        public void LoadMessagesForCustomer(int customerId)
        {
            var customerMessages = _messagesGroupedByCustomer.FirstOrDefault(g => g.Key == customerId);
            if (customerMessages != null)
            {
                SelectedCustomerMessages = new ObservableCollection<Message>(customerMessages);
            }
        }
        public void SendMessage()
        {
            if (SelectedCustomerMessages != null && SelectedCustomerMessages.Any() && !string.IsNullOrWhiteSpace(NewMessageContent))
            {
                var newMessage = new Message
                {
                    Content = NewMessageContent,
                    Timestamp = DateTime.Now,
                    Sender = "admin", // or the current user's name
                    CustomerID = SelectedCustomerMessages.First().CustomerID,
                    Name = "admin"
                };
                SelectedCustomerMessages.Add(newMessage);
                NewMessageContent = string.Empty;
                // Optionally, save the message to the database
                _daoMessage.InsertMessage(newMessage);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
