using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellingTree.Model;

namespace SellingTree.IDao
{
    public class MockDao : IDao
    {
        public List<Blog> GetBlogs()
        {
            return new List<Blog>
            {
                new Blog
                {
                    Title = "Blog 1",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ImageLocation = "../Assets/blog01.jpg",
                    Likes = 10,
                    Views = 100
                },
                new Blog
                {
                    Title = "Blog 2",
                    Description = "Adipiscing sociosqu in vivamus euismod blandit sodales pulvinar lacus. Conubia ac ultricies dictum; cursus ac ex. Cursus felis lacinia natoque ullamcorper non a; nisi nisi. Nibh odio volutpat mi habitasse, suscipit et iaculis viverra. Suspendisse vehicula semper hac ullamcorper lacinia dignissim bibendum. Primis vulputate scelerisque accumsan consequat faucibus litora nisl penatibus. Suscipit diam urna placerat accumsan pretium justo. Eros diam nisi luctus mus iaculis.",
                    ImageLocation = "../Assets/blog02.jpg",
                    Likes = 20,
                    Views = 200
                },
                new Blog
                {
                    Title = "Blog 3",
                    Description = "Congue tempor suspendisse tristique finibus primis taciti interdum praesent non. Elementum amet himenaeos fames ante habitant etiam. Euismod ornare aliquet nam in lacinia ac dapibus ante. Sagittis netus litora nec urna, semper nam lacus litora imperdiet. Per curabitur eget nascetur, dignissim facilisis nibh euismod maximus sed. Vulputate eget volutpat praesent; montes quam euismod. Integer sagittis pharetra conubia fermentum hac cubilia himenaeos netus. Sem commodo etiam integer cursus est volutpat est curabitur. Class penatibus tempus aptent; ridiculus quisque cubilia.",
                    ImageLocation = "../Assets/blog03.jpg",
                    Likes = 30,
                    Views = 300
                },
               new Blog
                {
                    Title = "Blog 4",
                    Description = "Fusce potenti a rhoncus facilisi, leo netus finibus ridiculus. Auctor sit elit metus velit ultrices at. Sit magna rutrum ad maximus commodo amet ac et nunc. Sagittis rhoncus viverra tempor, velit congue dictumst maximus fermentum. Elit euismod mattis felis sagittis interdum platea. Duis fringilla felis nec; vitae odio ridiculus praesent. Eleifend libero augue maecenas at pretium egestas quam. Ad aliquet urna pulvinar vulputate eget eros volutpat. Interdum purus curabitur gravida iaculis non aliquet ad duis. Aenean rhoncus sociosqu libero potenti curabitur dictumst massa.",
                    ImageLocation = "../Assets/blog04.jpg",
                    Likes = 40,
                    Views = 400
                },
                new Blog
                {
                    Title = "Blog 5",
                    Description = "Nisi tellus fermentum venenatis duis mi at sem montes. Malesuada a torquent auctor, erat auctor magna phasellus. Est ridiculus facilisis hendrerit ligula vulputate. Convallis quisque lobortis platea porttitor quisque at malesuada nam. Fames natoque iaculis aptent; at curae vivamus. Dis pretium cursus placerat pulvinar dolor enim nascetur eros? Fames fusce pulvinar facilisi iaculis aenean dui.",
                    ImageLocation = "../Assets/blog05.jpg",
                    Likes = 50,
                    Views = 500
                }
            };
        }
    }

}
