using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql.PostgresTypes;
using SellingTree.Model;
using SellingTree.ViewModel;

namespace SellingTree.Helper
{
    public class ProductHandle
    {
        static ObservableCollection<Product> p = IDao.IDaoCollection.GetAllProduct();
        public static Product findProductByName(String name)
        {
            Product ans = null;

            for (int i = 0; i < p.Count; i++)
            {
                if (p[i].Name == name)
                {
                    ans = p[i];
                }
            }

            return ans;
        }
        public static Product findProductById(int id)
        {
            for (int i = 0; i < p.Count; i++)
            {
                if (p[i].PID == id)
                    return p[i];
            }

            return null;
        }

    }
}
