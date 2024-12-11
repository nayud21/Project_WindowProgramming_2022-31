using System;
using System.Collections.ObjectModel;

namespace SellingTree.Model
{
    public class Product : Plant
    {
        public int PID { get; set; }
        public string ImageSource { get; set; }

        public ObservableCollection<String> ImageSources { get; set; }
        = new ObservableCollection<String> ();
        public int Price { get; set; }
        public int Sold { get; set; }
        public int Stored { get; set; }
    }
}
