using SellingTree.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTree.IDao
{
    public interface IDaoBlog
    {
        List<Blog> GetBlogs();
    }
    public interface IDaoMessage
    {
        List<Message> GetMessages();
        List<Message> GetMessagesForCustomer(string customerName);

    }
    internal abstract class IDaoCollection
    {
        public  static ObservableCollection<Product> GetAllProduct()
        {
            return MockDaoCollection.GetAllProduct();
        }
    }

    public interface IDaoUser
    {
        List<User> GetUsers();
    }
}
