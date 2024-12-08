using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellingTree.Model;
using SellingTree.IDao;
namespace SellingTree.ViewModel
{
    public class BlogViewModel
    {
        public List<Blog> Blogs { get; set; }
        public BlogViewModel()
        {
            SellingTree.IDao.IDaoBlog dao = new PostgreDaoBlog();
            Blogs = dao.GetBlogs();
        }
    }
}
