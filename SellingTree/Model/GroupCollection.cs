using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTree.Model
{
    public class GroupCollection
    {

        private List<ProductCollection> _products;

        public GroupCollection()
        {

        }

        public GroupCollection(List<ProductCollection> products)
        {
            this._products = products;
        }

        public List<ProductCollection> Products
        {
            get
            {
                return this._products;
            }
            set {
                this._products = value;
            }
        }
        

    }
}
