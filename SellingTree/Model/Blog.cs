using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTree.Model
{
    public class Blog : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageLocation { get; set; }
        public int Likes { get; set; }
        public int Views { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
