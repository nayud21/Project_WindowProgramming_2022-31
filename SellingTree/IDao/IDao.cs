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
        public void InsertBlog(Blog blog);
    }
    public interface IDaoMessage
    {
        List<Message> GetMessages();
        List<Message> GetMessagesForCustomer(string customerName);

    }
    internal abstract class IDaoCollection
    {
        public static ObservableCollection<Product> GetAllProduct()
        {
            return PostgreDaoCollection.GetAllProduct();
        }
    }

    public interface IDaoUser
    {
        List<User> GetUsers();
    }
    public interface IDaoOrder
    {
        List<Order> GetOrders();
        List<Order> GetOrdersForCustomer(int customerID);
        public void InsertOrder(Order order);
    }
    public interface IDaoDetail
    {
        List<Detail> GetDetails();
        List<Detail> GetDetailsForOrder(int orderID);
        public void InsertDetail(Detail detail);
    }
}
