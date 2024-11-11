using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellingTree.Model;
using SellingTree.ViewModel;

namespace SellingTree.Helper
{
    public class ProductHandle
    {

        public static Product findProductByName(String name)
        {
            Product ans = null;

            MainViewViewModel productsViewModel = new MainViewViewModel();
            for(int i = 0; i < productsViewModel.products.Count; i++)
            {
                if (productsViewModel.products[i].Name == name) { 
                    ans = productsViewModel.products[i];
                }
            }

            return ans;
        }

    }
}
