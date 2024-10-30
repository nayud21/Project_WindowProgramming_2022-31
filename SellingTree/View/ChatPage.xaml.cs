using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SellingTree.IDao;
using SellingTree.ViewModel;
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
    public sealed partial class ChatPage : Page
    {
        public MessageViewModel ViewModel { get; set; }
        private MockDaoMessage daoMessage;

        public ChatPage()
        {
            this.InitializeComponent();
            ViewModel = new MessageViewModel();
            this.DataContext = ViewModel;
            daoMessage = new MockDaoMessage(); // Khởi tạo MockDaoMessage
        }

        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustomerListView.SelectedItem is ListViewItem selectedCustomer)
            {
                string customerName = selectedCustomer.Content.ToString();
                var messages = daoMessage.GetMessagesForCustomer(customerName); // Lấy tin nhắn của khách hàng
                ViewModel.Messages.Clear();
                foreach (var message in messages)
                {
                    ViewModel.Messages.Add(message); // Cập nhật danh sách tin nhắn trong ViewModel
                }
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            // Xử lý gửi tin nhắn
        }


    }
    public class HorizontalAlignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string sender = value as string;
            return sender == "Bạn" ? HorizontalAlignment.Right : HorizontalAlignment.Left;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class MarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string sender = value as string;
            return sender == "Bạn" ? new Thickness(50, 5, 0, 5) : new Thickness(0, 5, 50, 5);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class MessageBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string sender = value as string;
            return sender == "Bạn" ? new SolidColorBrush(ColorHelper.FromArgb(255, 85, 136, 59)) : new SolidColorBrush(ColorHelper.FromArgb(255, 104, 103, 53));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

}
