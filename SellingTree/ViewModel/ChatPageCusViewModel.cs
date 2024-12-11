using SellingTree.IDao;
using SellingTree.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SellingTree.ViewModel
{
    public class ChatPageCusViewModel : INotifyPropertyChanged
    {
        private readonly PostgreDaoMessage _daoMessage;
        private ObservableCollection<Message> _messages;
        private string _newMessageContent;
        private int _customerId;

        public ObservableCollection<Message> Messages
        {
            get => _messages;
            set
            {
                _messages = value;
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

        public ChatPageCusViewModel()
        {
            _daoMessage = new PostgreDaoMessage();
            Messages = new ObservableCollection<Message>();
        }

        public void SetCustomerId(int customerId)
        {
            _customerId = customerId;
            LoadMessages();
        }

        private async void LoadMessages()
        {
            var messages = await Task.Run(() => _daoMessage.GetMessagesForCustomer(_customerId));
            Messages = new ObservableCollection<Message>(messages.OrderBy(m => m.Timestamp));
        }

        public void SendMessage()
        {
            if (!string.IsNullOrWhiteSpace(NewMessageContent))
            {
                var newMessage = new Message
                {
                    Content = NewMessageContent,
                    Timestamp = DateTime.Now,
                    Sender = "Customer", // or the current user's name
                    CustomerID = _customerId,
                    Name = SessionManager.CurrentUser.Name
                };
                Messages.Add(newMessage);
                NewMessageContent = string.Empty;
                // Save the message to the database
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
