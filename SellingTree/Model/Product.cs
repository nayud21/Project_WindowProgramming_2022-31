using System;
using System.Collections.ObjectModel;

namespace SellingTree.Model
{
    public class Product : Plant
    {
        public string ImageSource { get; set; }

        public ObservableCollection<String> ImageSources { get; set; }
        public int Price { get; set; }
        public int Sold { get; set; }
        public int Stored { get; set; }
    }
}
