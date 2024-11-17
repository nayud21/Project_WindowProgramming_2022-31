using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media.Imaging;
using SellingTree.Helper;

namespace SellingTree.Model
{
    public class ProductCollection
    {

        private Product _product;
        private String _meaning;
        private BitmapImage _image; 

        public ProductCollection(String nameProduct, String meaning)
        {
            _product = ProductHandle.findProductByName(nameProduct);
            _image = new BitmapImage(new Uri(_product.ImageSource));
            this._meaning = meaning;
        }

        public Product Product
        {
            get
            {
                return this._product;
            }
            private set
            {
                this._product = value;
            }
        }

        public String Meaning
        {
            get
            {
                return this._meaning;
            }
            private set
            {
                this._meaning = value;
            }
        }

        public BitmapImage Image
        {
            get
            {
                return this._image;
            }
            private set { this._image = value; }
        }

    }
}
