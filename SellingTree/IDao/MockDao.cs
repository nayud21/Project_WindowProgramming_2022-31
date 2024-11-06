using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using SellingTree.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTree.IDao
{
    public class MockDaoBlog : IDaoBlog
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
    public class MockDaoMessage : IDaoMessage
    {
        private Dictionary<string, List<Message>> messagesByCustomer = new Dictionary<string, List<Message>>
    {
        {
            "Khách 1", new List<Message>
            {
                new Message { Sender = "Khách 1", Content = "Xin chào!", Timestamp = DateTime.Now.AddMinutes(-15) },
                new Message { Sender = "Bạn", Content = "Chào bạn! Bạn cần hỗ trợ gì?", Timestamp = DateTime.Now.AddMinutes(-14) },
                new Message { Sender = "Khách 1", Content = "Tôi muốn mua sen đá siêu to bự.", Timestamp = DateTime.Now.AddMinutes(-13) },
                new Message { Sender = "Bạn", Content = "Hm.... Để tôi check trong kho.", Timestamp = DateTime.Now.AddMinutes(-12) }
            }
        },
        {
            "Khách 2", new List<Message>
            {
                new Message { Sender = "Khách 2", Content = "Hiện tại shop có chương trình khuyến mãi nào không?", Timestamp = DateTime.Now.AddMinutes(-10) },
                new Message { Sender = "Bạn", Content = "Hiện tại chúng tôi đang giảm giá 10% cho tất cả sản phẩm thuộc thể loại cây phong thủy.", Timestamp = DateTime.Now.AddMinutes(-9) }
            }

        },
        {
            "Khách 3", new List<Message>
            {
                new Message { Sender = "Khách 3", Content = "Chào shop", Timestamp = DateTime.Now.AddMinutes(-15) },
                new Message { Sender = "Bạn", Content = "Chào bạn! Bạn cần hỗ trợ gì?", Timestamp = DateTime.Now.AddMinutes(-14) },
                new Message { Sender = "Khách 3", Content = "Tôi muốn mua xương rồng không có gai.", Timestamp = DateTime.Now.AddMinutes(-13) },
                new Message { Sender = "Bạn", Content = "Xin lỗi quý khách.", Timestamp = DateTime.Now.AddMinutes(-12) },
                new Message { Sender = "Bạn", Content = "HIện tại chúng tôi tạm thời hết giống cây đó rồi ạ.", Timestamp = DateTime.Now.AddMinutes(-11) },
            }
        },
       
    };

        // 
        public List<Message> GetMessages()
        {
            List<Message> allMessages = new List<Message>();
            foreach (var customerMessages in messagesByCustomer.Values)
            {
                allMessages.AddRange(customerMessages);
            }
            return allMessages;
        }

        // Lay danh sach tin nhan cho khach hang cu the
        public List<Message> GetMessagesForCustomer(string customerName)
        {
            return messagesByCustomer.ContainsKey(customerName) ? messagesByCustomer[customerName] : new List<Message>();
        }
    }
    internal class MockDaoCollection: IDaoCollection
    {
        public static new ObservableCollection<Product> GetAllProduct()
        {

            return new ObservableCollection<Product>()
            {
                new Product() {Name = "Cây Bàng Cẩm Thạch", ImageSource="ms-appx:///Assets/Picture1.jpg",
                    Price = 400000, Description = "Cây A",
                    Sold = 420, Stored = 25,
                    ImageSources = new ObservableCollection<string>
                    { "ms-appx:///Assets/Picture5.jpg", "ms-appx:///Assets/Picture6.jpg"}
                },
                new Product() {Name = "Cây Dứa Đuôi Phụng", ImageSource="ms-appx:///Assets/Picture2.jpg",
                    Price = 50000, Description= "Cây B",
                    Sold = 1205, Stored = 73,
                    ImageSources = new ObservableCollection<string>
                    { "ms-appx:///Assets/Picture7.jpg"}
                },
                new Product() {Name = "Cây Khuynh Diệp", ImageSource="ms-appx:///Assets/Picture3.jpg",
                    Price = 150000, Description = "Cây C",
                    Sold = 80, Stored = 120,
                    ImageSources = new ObservableCollection<string>
                    {"ms-appx:///Assets/Picture8.jpg", "ms-appx:///Assets/Picture9.jpg",
                    "ms-appx:///Assets/Picture10.jpg","ms-appx:///Assets/Picture11.jpg"}
                },
                new Product() {Name = "Cây Đa Tam Phúc", ImageSource="ms-appx:///Assets/Picture4.jpg",
                    Price = 100000, Description = "Cây D",
                    Sold = 15, Stored = 443,
                    ImageSources = new ObservableCollection<string>{ "ms-appx:///Assets/Picture12.jpg" } },
            };

        }

        static public List<Review> GetAllReviews(Product product)
        {
            switch (product.Name)
            {
                case "Cây Bàng Cẩm Thạch":
                    return new List<Review>() {
                        new Review() {
                            AvatarSource = "ms-appx:///Assets/Picture1.jpg",
                            Username="Random User Guy", Score = 5,
                            Date = "31/10/2024 11:22:33",
                            Content = "Cây rất đẹp nhưng trồng khá lâu. " +
                            "Ủng hộ shop với các sản phẩm tiếp theo nhé!"
                        },

                        new Review()
                        {
                            AvatarSource = "ms-appx:///Assets/Picture1.jpg",
                            Username ="qwerty123", Score = 4,
                            Date = "1/11/2024 09:00:01",
                            Content = "Sản phẩm tạm ổn. Giao hơi lâu nên -1 sao."
                        }
                    };

                case "Cây Dứa Đuôi Phụng":
                    return new List<Review>() {
                        new Review()
                        {
                            AvatarSource = "ms-appx:///Assets/Picture1.jpg",
                            Username = "charlotte_@#$", Score = 1,
                            Date = "30/10/2024 23:59:27",
                            Content = "Hàng không giống như mô tả. Yêu cầu Shop liên hệ và đổi trả."
                        }
                    };

                default: return new List<Review>();
            }
        }
    }

    public class MockDaoCollectionGroup
    {
        public static List<GroupCollection> getInstance()
        {
            return new List<GroupCollection>() {

                //spring
                new GroupCollection()
                {
                    ListImages = new List<BitmapImage>()
                    {
                        new BitmapImage(new Uri("ms-appx:///Assets/SeasonCollection/dao.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/SeasonCollection/mai.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/SeasonCollection/camchuong.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/SeasonCollection/luuly.jpg")),
                    },
                    ListNames = new List<string>()
                    {
                        new String("Hoa Đào"),
                        new String("Hoa Mai"),
                        new String("Hoa Cẩm Chướng"),
                        new String("Hoa Lưu Ly"),
                    },
                },

                //summer
                new GroupCollection()
                {
                    ListImages = new List<BitmapImage>()
                    {
                        new BitmapImage(new Uri("ms-appx:///Assets/SeasonCollection/camtucau.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/SeasonCollection/phuong.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/SeasonCollection/bang.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/SeasonCollection/huongduong.jpg")),
                    },
                    ListNames = new List<string>()
                    {
                        new String("Hoa Cẩm Tú Cầu"),
                        new String("Hoa Phượng"),
                        new String("Hoa/Cây Bàng"),
                        new String("Hoa Hướng Dương"),
                    },
                },

                //autumn
                new GroupCollection()
                {
                    ListImages = new List<BitmapImage>()
                    {
                        new BitmapImage(new Uri("ms-appx:///Assets/SeasonCollection/cuchoami.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/SeasonCollection/hongvang.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/SeasonCollection/sua.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/SeasonCollection/thachthao.jpg")),
                    },
                    ListNames = new List<string>()
                    {
                        new String("Hoa Cúc Họa Mi"),
                        new String("Hoa Hồng Vàng"),
                        new String("Hoa Sữa"),
                        new String("Hoa Thạch Thảo"),
                    },
                },

                //winter
                new GroupCollection()
                {
                    ListImages = new List<BitmapImage>()
                    {
                        new BitmapImage(new Uri("ms-appx:///Assets/SeasonCollection/dialan.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/SeasonCollection/nhai.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/SeasonCollection/thuytien.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/SeasonCollection/tuongvi.jpg")),
                    },
                    ListNames = new List<string>()
                    {
                        new String("Hoa Địa Lan"),
                        new String("Hoa Nhài"),
                        new String("Hoa Thủy Tiên"),
                        new String("Hoa Tường Vi"),
                    },
                },

                //wealth
                new GroupCollection()
                {
                    ListImages = new List<BitmapImage>()
                    {
                        new BitmapImage(new Uri("ms-appx:///Assets/FengShuiCollection/kimtien.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/FengShuiCollection/thantai.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/FengShuiCollection/ngocbich.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/FengShuiCollection/bachmahoangtu.jpg")),
                    },
                    ListNames = new List<string>()
                    {
                        new String("Cây Kim Tiền"),
                        new String("Cây Thần Tài"),
                        new String("Cây Ngọc Bích"),
                        new String("Cây Bạch Mã Hoàng Tử"),
                    },
                },

                //health
                new GroupCollection()
                {
                    ListImages = new List<BitmapImage>()
                    {
                        new BitmapImage(new Uri("ms-appx:///Assets/FengShuiCollection/luoiho.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/FengShuiCollection/nhadam.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/FengShuiCollection/vannienthanh.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/FengShuiCollection/nhatmathuong.jpg")),
                    },
                    ListNames = new List<string>()
                    {
                        new String("Cây Lưỡi Hổ"),
                        new String("Cây Nha Đam"),
                        new String("Cây Vạn Niên Thanh"),
                        new String("Cây Nhất Mạt Hương"),
                    },
                },

                //love
                new GroupCollection()
                {
                    ListImages = new List<BitmapImage>()
                   {
                        new BitmapImage(new Uri("ms-appx:///Assets/FengShuiCollection/lanquantu.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/FengShuiCollection/trauba.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/FengShuiCollection/hongmon.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/FengShuiCollection/camnhung.jpg")),
                    },
                    ListNames = new List<string>()
                    {
                        new String("Cây Lan Quân Tử"),
                        new String("Cây Trầu Bà"),
                        new String("Cây Hồng Môn"),
                        new String("Cây Cẩm Nhung"),
                    },
                },

                //career
                new GroupCollection()
                {
                    ListImages = new List<BitmapImage>()
                    {
                        new BitmapImage(new Uri("ms-appx:///Assets/FengShuiCollection/kimngan.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/FengShuiCollection/tungbonglai.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/FengShuiCollection/phuquy.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/FengShuiCollection/lany.jpg")),
                    },
                    ListNames = new List<string>()
                    {
                        new String("Cây Kim Ngân"),
                        new String("Cây Tùng Bồng Lai"),
                        new String("Cây Phú Quý"),
                        new String("Cây Lan Ý"),
                    },
               },

                //family
                new GroupCollection()
                {
                    ListImages = new List<BitmapImage>()
                    {
                        new BitmapImage(new Uri("ms-appx:///Assets/FengShuiCollection/conhat.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/FengShuiCollection/huongthao.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/FengShuiCollection/xuongrong.jpg")),
                        new BitmapImage(new Uri("ms-appx:///Assets/FengShuiCollection/duoicong.jpg")),
                    },
                    ListNames = new List<string>()
                    {
                        new String("Cây Cọ Nhật"),
                        new String("Cây Hương Thảo"),
                        new String("Cây Xương Rồng"),
                        new String("Cây Đuôi Công"),
                    },
                },


            };
        }
            
    }

}
