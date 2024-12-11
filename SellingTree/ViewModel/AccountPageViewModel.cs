using SellingTree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellingTree.IDao;
namespace SellingTree.ViewModel
{
    public  class AccountPageViewModel
    {
        public List<Order> Accounts { get; set; }
        public AccountPageViewModel()
        {
            SellingTree.IDao.IDaoOrder dao = new PostgreDaoOrder();
            Accounts = dao.GetOrders();
        }
    }
}
