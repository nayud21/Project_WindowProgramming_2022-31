using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellingTree.Model;
using SellingTree.IDao;

namespace SellingTree.ViewModel
{
    public class GroupCollectionViewModel
    {

        public List<GroupCollection> GroupCollections { get; set; }

        public GroupCollectionViewModel()
        {
            GroupCollections = MockDaoCollectionGroup.getInstance();
        }

    }
}
