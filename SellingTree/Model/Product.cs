using System;
using System.Collections.ObjectModel;

namespace SellingTree.Model
{
    public class Product
    {
        public string ImageSource { get; set; }

        public ObservableCollection<String> ImageSources { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
