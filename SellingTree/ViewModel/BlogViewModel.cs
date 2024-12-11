using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellingTree.Model;
using SellingTree.IDao;
using System.Collections.ObjectModel;
namespace SellingTree.ViewModel
{
    public class BlogViewModel
    {
        public ObservableCollection<Blog> Blogs { get; set; }

        public BlogViewModel()
        {
            SellingTree.IDao.IDaoBlog dao = new PostgreDaoBlog();
            var blogs = dao.GetBlogs();
            Blogs = new ObservableCollection<Blog>(blogs);
        }

    }
}
