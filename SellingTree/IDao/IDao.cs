using Npgsql.Replication.PgOutput.Messages;
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
        public void DeleteBlog(Blog blog);
    }
    public interface IDaoMessage
    {
        List<Message> GetMessages();
        List<Message> GetMessagesForCustomer(int customerID);
        Dictionary<int, List<Message>> GetMessagesGroupedByCustomer();
        public void InsertMessage(Message message);

    }
    internal abstract class IDaoCollection
    {
        public static ObservableCollection<Product> GetAllProduct()
        {
            return PostgreDaoCollection.GetAllProduct();
        }
        internal static Tuple<FullObservableCollection<Product>, int> GetProductAtPage(int v)
        {
            return PostgreDaoCollection.GetProductAtPage(v);
        }

    }
    public interface IDaoProduct
    {
        public void InsertProduct(Product product);
        public void DeleteProduct(Product product);
        public void UpdateProduct(Product product);
    }
    public interface IDaoUser
    {
        List<User> GetUsers();
        public void InsertUser(User user);
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
        public void InsertDetail(List<Detail> detail, User user, DateTime date);
    }
}
