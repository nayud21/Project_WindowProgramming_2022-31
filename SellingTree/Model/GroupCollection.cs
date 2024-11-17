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


        private List<ProductCollection> _listProduct;

        public List<ProductCollection> ProductCollection
        {
            get
            {
                return this._listProduct;
            }
            set
            {
                this._listProduct = value;
            }
        }

    }
}
