using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTree.Model
{
    public class User : INotifyPropertyChanged
    {
        public int UserId { get; set; }  
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string ImageLocation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
