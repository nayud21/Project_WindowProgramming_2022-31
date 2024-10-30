using SellingTree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTree.IDao
{
    public class MockDaoMessage : IDaoMessage
    {
        private Dictionary<string, List<Message>> messagesByCustomer = new Dictionary<string, List<Message>>
    {
        {
            "Khách 1", new List<Message>
            {
                new Message { Sender = "Khách 1", Content = "Xin chào!", Timestamp = DateTime.Now.AddMinutes(-15) },
                new Message { Sender = "Bạn", Content = "Chào bạn! Bạn cần hỗ trợ gì?", Timestamp = DateTime.Now.AddMinutes(-14) },
                new Message { Sender = "Khách 1", Content = "Tôi muốn mua sen đá siêu to bự.", Timestamp = DateTime.Now.AddMinutes(-13) },
                new Message { Sender = "Bạn", Content = "Hm.... Để tôi check trong kho.", Timestamp = DateTime.Now.AddMinutes(-12) }
            }
        },
        {
            "Khách 2", new List<Message>
            {
                new Message { Sender = "Khách 2", Content = "Hiện tại shop có chương trình khuyến mãi nào không?", Timestamp = DateTime.Now.AddMinutes(-10) },
                new Message { Sender = "Bạn", Content = "Hiện tại chúng tôi đang giảm giá 10% cho tất cả sản phẩm thuộc thể loại cây phong thủy.", Timestamp = DateTime.Now.AddMinutes(-9) }
            }

        },
        {
            "Khách 3", new List<Message>
            {
                new Message { Sender = "Khách 3", Content = "Chào shop", Timestamp = DateTime.Now.AddMinutes(-15) },
                new Message { Sender = "Bạn", Content = "Chào bạn! Bạn cần hỗ trợ gì?", Timestamp = DateTime.Now.AddMinutes(-14) },
                new Message { Sender = "Khách 3", Content = "Tôi muốn mua xương rồng không có gai.", Timestamp = DateTime.Now.AddMinutes(-13) },
                new Message { Sender = "Bạn", Content = "Xin lỗi quý khách.", Timestamp = DateTime.Now.AddMinutes(-12) },
                new Message { Sender = "Bạn", Content = "HIện tại chúng tôi tạm thời hết giống cây đó rồi ạ.", Timestamp = DateTime.Now.AddMinutes(-11) },
            }
        },
       
    };

        // 
        public List<Message> GetMessages()
        {
            List<Message> allMessages = new List<Message>();
            foreach (var customerMessages in messagesByCustomer.Values)
            {
                allMessages.AddRange(customerMessages);
            }
            return allMessages;
        }

        // Lay danh sach tin nhan cho khach hang cu the
        public List<Message> GetMessagesForCustomer(string customerName)
        {
            return messagesByCustomer.ContainsKey(customerName) ? messagesByCustomer[customerName] : new List<Message>();
        }
    }
}
