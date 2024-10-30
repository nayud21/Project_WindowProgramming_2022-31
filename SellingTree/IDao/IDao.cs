
using System;
using SellingTree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SellingTree.Model;

namespace SellingTree.IDao
{
    public interface IDao
    {
        List<Blog> GetBlogs();
    }
    public interface IDaoMessage
    {
        List<Message> GetMessages();
        List<Message> GetMessagesForCustomer(string customerName);

    }
}
