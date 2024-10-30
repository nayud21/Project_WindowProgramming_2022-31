using SellingTree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTree.IDao
{
    public interface IDaoMessage
    {
        List<Message> GetMessages();
        List<Message> GetMessagesForCustomer(string customerName);
    }
}
