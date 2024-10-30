using SellingTree.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTree.ViewModel
{
    public class MessageViewModel
    {
        public ObservableCollection<Message> Messages { get; set; }

        public MessageViewModel()
        {
            Messages = new ObservableCollection<Message>();
        }
    }
}
