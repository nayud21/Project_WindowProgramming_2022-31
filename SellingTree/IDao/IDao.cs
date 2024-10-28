using SellingTree.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTree.IDao
{
    internal abstract class IDao
    {
        public  static ObservableCollection<Product> GetAllProduct()
        {
            return MockDao.GetAllProduct();
        }
    }
}
