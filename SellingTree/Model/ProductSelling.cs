using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTree.Model
{
    public class ProductSelling : Product
    {

        public String ImageSource { get; set; }
        public ObservableCollection<String> ImageSources { get; set; }
        public int Price { get; set; }
        public int Sold { get; set; }
        public int Stored { get; set; }

    }
}
