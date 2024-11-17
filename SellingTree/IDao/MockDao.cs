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
                new Message { Sender = "Bạn", Content = "Hiện tại chúng tôi tạm thời hết giống cây đó rồi ạ.", Timestamp = DateTime.Now.AddMinutes(-11) },
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
                    Price = 400000, Sold = 420, Stored = 25,
                    Description = "Cây Bàng Cẩm Thạch là một giống cây cảnh phổ biến, có nguồn gốc từ Ấn Độ " +
                    "và Malaysia. Đặc điểm nổi bật của cây là lá lớn, dày, bóng, với các mảng màu xanh và " +
                    "trắng xen kẽ tạo nên vẻ đẹp độc đáo. Cây thích hợp làm cây cảnh trong nhà và có khả " +
                    "năng lọc không khí rất tốt.",
                    ImageSources = new ObservableCollection<string>
                    { "ms-appx:///Assets/Picture5.jpg", "ms-appx:///Assets/Picture6.jpg"}
                },
                new Product() {Name = "Cây Dứa Đuôi Phụng", ImageSource="ms-appx:///Assets/Picture2.jpg",
                    Price = 50000, Sold = 1205, Stored = 73,
                    Description = "Cây Dứa Đuôi Phụng là loài thực vật biểu sinh thuộc họ Bromeliaceae, có " +
                    "nguồn gốc từ vùng nhiệt đới châu Mỹ. Cây có hoa màu đỏ, cam, vàng hoặc hồng rực rỡ, mọc " +
                    "thành cụm lớn ở trung tâm, thu hút sự chú ý. Lá cây dài, màu xanh đậm, xếp thành hình " +
                    "hoa thị. Cây thích hợp trang trí trong nhà với ánh sáng gián tiếp.",
                    ImageSources = new ObservableCollection<string>
                    { "ms-appx:///Assets/Picture7.jpg"}
                },
                new Product() {Name = "Cây Khuynh Diệp", ImageSource="ms-appx:///Assets/Picture3.jpg",
                    Price = 150000, Sold = 80, Stored = 120,
                    Description = "Cây Khuynh Diệp là loài cây gỗ lớn, thuộc họ Myrtaceae, có nguồn gốc từ Úc. " +
                    "Cây có lá dài, hẹp, màu xanh bạc và mùi hương đặc trưng giúp xua đuổi côn trùng. Tinh dầu " +
                    "khuynh diệp được chiết xuất từ lá cây, có nhiều công dụng trong y học và sản xuất mỹ phẩm. " +
                    "Cây thường được trồng để lấy gỗ và làm cảnh.",
                    ImageSources = new ObservableCollection<string>
                    {"ms-appx:///Assets/Picture8.jpg", "ms-appx:///Assets/Picture9.jpg",
                    "ms-appx:///Assets/Picture10.jpg","ms-appx:///Assets/Picture11.jpg"}
                },
                new Product() {Name = "Cây Đa Tam Phúc", ImageSource="ms-appx:///Assets/Picture4.jpg",
                    Price = 100000, Sold = 15, Stored = 443,
                    Description = "Cây Đa Tam Phúc, còn gọi là cây Đa Búp Đỏ hoặc cây Bồ Đề, là một loài cây " +
                    "cảnh thuộc họ Moraceae. Cây có thân gỗ nhỏ, lá hình trái tim, màu xanh đậm, và mặt dưới " +
                    "lá thường có màu đỏ đặc trưng. Cây Đa Tam Phúc thích hợp trồng trong nhà, với khả năng " +
                    "chịu bóng và lọc không khí tốt.",
                    ImageSources = new ObservableCollection<string>{ "ms-appx:///Assets/Picture12.jpg" }
                },
                new Product() {Name = "Cây tùng tuyết", ImageSource="ms-appx:///Assets/Picture13.jpg",
                    Price = 150000, Sold = 80, Stored = 120,
                    Description = "Cây tùng tuyết một trong những loại cây cảnh để bàn đẹp, có thể gọi chúng " +
                    "là cây tuyết tùng, thuộc họ nhà Thông. Với thân cây gỗ có rất nhiều cành và lá của cây " +
                    "mọc ôm lấy nhau giống hình xoắn ốc. Hiện nay con người trồng và sử dụng loại cây này với " +
                    "nhiều tác dụng khác nhau. Cây có thể làm cây cảnh ngoại thất hoặc nội thất hoặc làm cây " +
                    "cảnh bonsai đẹp",
                    ImageSources = new ObservableCollection<string>
                    {"ms-appx:///Assets/Picture14.jpg", "ms-appx:///Assets/Picture15.jpg"}
                },
                new Product() {Name = "Cây Ngũ Gia Bì", ImageSource="ms-appx:///Assets/Picture16.jpg",
                    Price = 150000, Sold = 80, Stored = 120,
                    Description = "Cây Ngũ Gia Bì là loại cây thường được sử dụng để trưng bày trên các góc " +
                    "bàn làm việc với tính chất trang trí cao. Loại cây Ngũ Gia Bì này thường rất được ưa " +
                    "chuộng để trưng bày và trang trí tại cái cổng ra vào của công ty, khách sạn,….",
                    ImageSources = new ObservableCollection<string>
                    {"ms-appx:///Assets/Picture17.jpg", "ms-appx:///Assets/Picture18.jpg"}
                },
                new Product() {Name = "Cây Sống Đời", ImageSource="ms-appx:///Assets/Picture19.jpg",
                    Price = 150000, Sold = 80, Stored = 120,
                    Description = "Cây Sống Đời thuộc thân thảo và phân nhánh, sau khi trưởng thành có thể " +
                    "cao tới 1m. Thân cây nhẵn, có màu xanh hoặc tím, nở hoa vào mùa xuân. Hoa sẽ mọc thành " +
                    "từng chùm màu đỏ, cam, vàng hoặc trắng... Tuy bề ngoài nhỏ nhắn song cây Sống Đời mang " +
                    "tới sức mạnh bền bỉ y như tên gọi. Lá cây khi rụng sẽ mọc thành rễ và tạo thành cây con. " +
                    "Điều này cho thấy sự sống vĩnh cửu của loài cây này.",
                    ImageSources = new ObservableCollection<string>
                    {"ms-appx:///Assets/Picture20.jpg", "ms-appx:///Assets/Picture21.jpg"}
                },

                //spring
                new Product()
                {
                    Name = new String("Hoa Đào"),
                    ImageSource = "ms-appx:///Assets/SeasonCollection/dao.jpg",
                    Description = "Cánh hoa mỏng, màu hồng hoặc đỏ, có mùi thơm nhẹ. Hoa đào thường nở vào dịp Tết Nguyên Đán ở Việt Nam.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Hoa Mai"),
                    ImageSource = "ms-appx:///Assets/SeasonCollection/mai.jpg",
                    Description = "Hoa mai có màu vàng tươi, cánh hoa mỏng, nở vào mùa xuân, đặc biệt phổ biến trong dịp Tết Nguyên Đán miền Nam Việt Nam.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Hoa Cẩm Chướng"),
                    ImageSource = "ms-appx:///Assets/SeasonCollection/camchuong.jpg",
                    Description = "Cánh hoa mềm mại, có nhiều màu sắc như đỏ, hồng, trắng, vàng. Hoa có hương thơm nhẹ nhàng, thường được trồng làm cây cảnh trong vườn.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Hoa Lưu Ly"),
                    ImageSource = "ms-appx:///Assets/SeasonCollection/luuly.jpg",
                    Description = "Hoa có màu xanh dương nhạt, hình dáng nhỏ và xinh xắn, mọc thành chùm.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                //summer
                new Product()
                {
                    Name = new String("Hoa Cẩm Tú Cầu"),
                    ImageSource = "ms-appx:///Assets/SeasonCollection/camtucau.jpg",
                    Description = "Cánh hoa có màu sắc đa dạng như xanh, hồng, tím, trắng. Hoa mọc thành chùm to, dễ trồng và chăm sóc.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Hoa Phượng"),
                    ImageSource = "ms-appx:///Assets/SeasonCollection/phuong.jpg",
                    Description = "Hoa phượng có màu đỏ rực rỡ, mọc thành chùm lớn. Thường nở rộ vào cuối hè, đầu thu.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Hoa/Cây Bàng"),
                    ImageSource = "ms-appx:///Assets/SeasonCollection/bang.jpg",
                    Description = "Cây bàng có lá lớn, dày và rụng vào mùa thu. Quả bàng có hình dáng đặc biệt và thường được dùng trong y học cổ truyền.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Hoa Hướng Dương"),
                    ImageSource = "ms-appx:///Assets/SeasonCollection/huongduong.jpg",
                    Description = "Hoa có màu vàng tươi, trung tâm hoa màu nâu, luôn quay về phía mặt trời. Thường được trồng để thu hoạch hạt.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                //autumn
                new Product()
                {
                    Name = new String("Hoa Cúc Họa Mi"),
                    ImageSource = "ms-appx:///Assets/SeasonCollection/cuchoami.jpg",
                    Description = "Hoa có màu trắng tinh khôi, nhỏ và nở thành từng chùm. Thường nở vào mùa thu và được ưa chuộng trong các dịp lễ Tết.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Hoa Hồng Vàng"),
                    ImageSource = "ms-appx:///Assets/SeasonCollection/hongvang.jpg",
                    Description = "Cánh hoa mềm mại, màu vàng tươi, hương thơm dễ chịu. Hoa hồng vàng thường được sử dụng trong các dịp tặng quà.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Hoa Sữa"),
                    ImageSource = "ms-appx:///Assets/SeasonCollection/sua.jpg",
                    Description = "Hoa sữa gắn liền với mùa thu, tạo cảm giác lãng mạn và thơ mộng.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Hoa Thạch Thảo"),
                    ImageSource = "ms-appx:///Assets/SeasonCollection/thachthao.jpg",
                    Description = "Hoa có màu sắc phong phú như tím, hồng, trắng, và vàng. Nó nở vào mùa thu và thường được trồng trong vườn.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                //winter
                new Product()
                {
                    Name = new String("Hoa Địa Lan"),
                    ImageSource = "ms-appx:///Assets/SeasonCollection/dialan.jpg",
                    Description = "Hoa có màu sắc đa dạng như vàng, trắng, hồng, đỏ. Thường nở vào mùa xuân và rất được ưa chuộng trong các dịp lễ Tết.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Hoa Nhài"),
                    ImageSource = "ms-appx:///Assets/SeasonCollection/nhai.jpg",
                    Description = "Hoa nhài có màu trắng hoặc vàng nhạt, với những cánh hoa mềm mại và hương thơm ngọt ngào.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Hoa Thủy Tiên"),
                    ImageSource = "ms-appx:///Assets/SeasonCollection/thuytien.jpg",
                    Description = "Hoa có màu trắng hoặc vàng, hình dáng đẹp và thường nở vào mùa xuân.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Hoa Tường Vi"),
                    ImageSource = "ms-appx:///Assets/SeasonCollection/tuongvi.jpg",
                    Description = "Hoa có màu hồng, đỏ, tím và thường nở vào mùa xuân.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                //wealth
                new Product()
                {
                    Name = new String("Cây Kim Tiền"),
                    ImageSource = "ms-appx:///Assets/FengShuiCollection/kimtien.jpg",
                    Description = "Cây có lá xanh bóng, mọc thành chùm, dễ trồng và sống lâu.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Cây Thần Tài"),
                    ImageSource = "ms-appx:///Assets/FengShuiCollection/thantai.jpg",
                    Description = "Cây có lá dày, hình tròn giống đồng xu, dễ chăm sóc và sống lâu.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Cây Ngọc Bích"),
                    ImageSource = "ms-appx:///Assets/FengShuiCollection/ngocbich.jpg",
                    Description = "Cây có lá dày, mọng nước, thường có màu xanh đậm. Được trồng trong nhà để thu hút tài lộc.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Cây Bạch Mã Hoàng Tử"),
                    ImageSource = "ms-appx:///Assets/FengShuiCollection/bachmahoangtu.jpg",
                    Description = "Cây có lá màu xanh đốm trắng, thường được trồng làm cây cảnh trong nhà.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                //health
                new Product()
                {
                    Name = new String("Cây Lưỡi Hổ"),
                    ImageSource = "ms-appx:///Assets/FengShuiCollection/luoiho.jpg",
                    Description = "Cây có lá dài, cứng và hình lưỡi kiếm, dễ chăm sóc và rất bền vững.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Cây Nha Đam"),
                    ImageSource = "ms-appx:///Assets/FengShuiCollection/nhadam.jpg",
                    Description = "Lá cây mọng nước, có tác dụng làm dịu da và chữa các bệnh ngoài da. Cây dễ trồng và có tác dụng trong y học.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Cây Vạn Niên Thanh"),
                    ImageSource = "ms-appx:///Assets/FengShuiCollection/vannienthanh.jpg",
                    Description = "Cây có lá xanh với những đốm trắng, dễ chăm sóc và thích hợp cho không gian trong nhà.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Cây Nhất Mạt Hương"),
                    ImageSource = "ms-appx:///Assets/FengShuiCollection/nhatmathuong.jpg",
                    Description = "Cây có thân gỗ nhỏ và lá xanh đậm, khi nở có mùi hương nhẹ nhàng đặc trưng.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                //love
                new Product()
                {
                    Name = new String("Cây Lan Quân Tử"),
                    ImageSource = "ms-appx:///Assets/FengShuiCollection/lanquantu.jpg",
                    Description = "Cây có hoa đỏ, hồng hoặc trắng, mọc thành chùm. Cây dễ chăm sóc và có thể trồng trong môi trường bóng râm.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Cây Trầu Bà"),
                    ImageSource = "ms-appx:///Assets/FengShuiCollection/trauba.jpg",
                    Description = "Cây có lá hình trái tim, xanh bóng, mọc thành chùm. Cây rất dễ sống và thích hợp với những không gian thiếu ánh sáng.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Cây Hồng Môn"),
                    ImageSource = "ms-appx:///Assets/FengShuiCollection/hongmon.jpg",
                    Description = "Cây hồng môn có hoa màu đỏ, hồng hoặc trắng, lá xanh bóng, tạo điểm nhấn trong không gian sống.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Cây Cẩm Nhung"),
                    ImageSource = "ms-appx:///Assets/FengShuiCollection/camnhung.jpg",
                    Description = "Cây cẩm nhung có lá lớn, màu sắc đa dạng từ đỏ, tím đến xanh, tạo nên sự nổi bật.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                //career
                new Product()
                {
                    Name = new String("Cây Kim Ngân"),
                    ImageSource = "ms-appx:///Assets/FengShuiCollection/kimngan.jpg",
                    Description = "Cây kim ngân có thân mềm, lá xanh mượt, rất dễ trồng và chăm sóc.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Cây Tùng Bồng Lai"),
                    ImageSource = "ms-appx:///Assets/FengShuiCollection/tungbonglai.jpg",
                    Description = "Cây tùng bồng lai có dáng cao, lá nhỏ, có khả năng sống lâu và thích hợp với khí hậu mát mẻ.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Cây Phú Quý"),
                    ImageSource = "ms-appx:///Assets/FengShuiCollection/phuquy.jpg",
                    Description = "Cây phú quý có lá màu đỏ hoặc cam rực rỡ, tạo điểm nhấn cho không gian sống.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Cây Lan Ý"),
                    ImageSource = "ms-appx:///Assets/FengShuiCollection/lany.jpg",
                    Description = "Cây lan ý có hoa trắng, lá xanh bóng, giúp thanh lọc không khí.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                //family
                new Product()
                {
                    Name = new String("Cây Cọ Nhật"),
                    ImageSource = "ms-appx:///Assets/FengShuiCollection/conhat.jpg",
                    Description = "Cây cọ nhật có thân thẳng, lá dài, mọc thành cụm, có thể chịu bóng râm và dễ chăm sóc.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Cây Hương Thảo"),
                    ImageSource = "ms-appx:///Assets/FengShuiCollection/huongthao.jpg",
                    Description = "Cây hương thảo có lá nhỏ, dày, có mùi thơm đặc trưng và dùng làm gia vị hoặc tinh dầu.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Cây Xương Rồng"),
                    ImageSource = "ms-appx:///Assets/FengShuiCollection/xuongrong.jpg",
                    Description = "Cây xương rồng có hình dáng đặc biệt, mọng nước và có gai nhọn. Nó sống trong điều kiện khô cằn.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },

                new Product()
                {
                    Name = new String("Cây Đuôi Công"),
                    ImageSource = "ms-appx:///Assets/FengShuiCollection/duoicong.jpg",
                    Description = "Cây đuôi công có lá lớn, mọc thành hình dáng đặc biệt, có hoa nhiều màu sắc.",

                    Price = 0, Sold = 0, Stored = 0,
                    ImageSources = new ObservableCollection<string>{ }

                },


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
                    ProductCollection = new List<ProductCollection>{
                        new ProductCollection("Hoa Đào", "Hoa đào là biểu tượng của mùa xuân, sự tươi mới và may mắn, đặc biệt trong dịp Tết Nguyên Đán. Đào còn gắn liền với văn hóa dân gian của người Việt, thể hiện sự hạnh phúc và bình an."),
                        new ProductCollection("Hoa Mai", "Hoa mai là biểu tượng của sự thịnh vượng, phát tài và may mắn trong dịp Tết. Nó còn thể hiện sự phú quý và bình an."),
                        new ProductCollection("Hoa Cẩm Chướng", "Hoa cẩm chướng thường được dùng để thể hiện tình yêu, sự ngưỡng mộ và sự tôn trọng."),
                        new ProductCollection("Hoa Lưu Ly", "Hoa lưu ly thường gắn liền với những kỷ niệm đẹp, thể hiện tình yêu vĩnh cửu và sự trung thủy."),
                    }
                },

                //summer
                new GroupCollection()
                {
                    ProductCollection = new List<ProductCollection>{
                        new ProductCollection("Hoa Cẩm Tú Cầu", "Hoa cẩm tú cầu biểu tượng cho sự giàu có, sự cảm ơn và sự tha thứ."),
                        new ProductCollection("Hoa Phượng", "Hoa phượng là biểu tượng của mùa hè, tuổi trẻ và những kỷ niệm học trò. Nó cũng tượng trưng cho sự nhiệt huyết và lòng yêu đời."),
                        new ProductCollection("Hoa/Cây Bàng", "Cây bàng gắn liền với hình ảnh bãi biển, thiên nhiên tươi đẹp và sự yên bình."),
                        new ProductCollection("Hoa Hướng Dương", "Hoa hướng dương biểu tượng cho sự nhiệt huyết, hi vọng và sự trung thành."),
                    }
                },

                //autumn
                new GroupCollection()
                {
                    ProductCollection = new List<ProductCollection>{
                        new ProductCollection("Hoa Cúc Họa Mi", "Hoa cúc họa mi là biểu tượng của sự thanh cao, trong sáng và thuần khiết."),
                        new ProductCollection("Hoa Hồng Vàng", "Hoa hồng vàng tượng trưng cho tình bạn, sự tôn trọng và lòng biết ơn."),
                        new ProductCollection("Hoa Sữa", "Hoa sữa gắn liền với mùa thu, tạo cảm giác lãng mạn và thơ mộng."),
                        new ProductCollection("Hoa Thạch Thảo", "Hoa sữa gắn liền với mùa thu, tạo cảm giác lãng mạn và thơ mộng."),
                    }
                },

                //winter
                new GroupCollection()
                {
                    ProductCollection = new List<ProductCollection>{
                        new ProductCollection("Hoa Địa Lan", "Hoa địa lan là biểu tượng của sự quý phái, sang trọng và tài lộc."),
                        new ProductCollection("Hoa Nhài", "Hoa nhài tượng trưng cho tình yêu trong sáng, sự thuần khiết và dịu dàng. Nó cũng mang ý nghĩa của sự thanh tao và hiền hòa."),
                        new ProductCollection("Hoa Thủy Tiên", "Hoa thủy tiên là biểu tượng của sự tái sinh, sự thuần khiết và hy vọng."),
                        new ProductCollection("Hoa Tường Vi", "Hoa tường vi tượng trưng cho tình yêu, sự kiên cường và sự vĩnh cửu."),
                    }
                },

                //wealth
                new GroupCollection()
                {
                    ProductCollection = new List<ProductCollection>{
                        new ProductCollection("Cây Kim Tiền", "Cây kim tiền tượng trưng cho tài lộc, sự phát đạt và may mắn."),
                        new ProductCollection("Cây Thần Tài", "Cây thần tài mang ý nghĩa tài lộc và may mắn."),
                        new ProductCollection("Cây Ngọc Bích", "Cây ngọc bích là biểu tượng của sự thịnh vượng và tài lộc."),
                        new ProductCollection("Cây Bạch Mã Hoàng Tử", "Cây bạch mã hoàng tử là biểu tượng của sự may mắn, tài lộc và sức khỏe."),
                    }
                },

                //health
                new GroupCollection()
                {
                    ProductCollection = new List<ProductCollection>{
                        new ProductCollection("Cây Lưỡi Hổ", "Cây lưỡi hổ mang lại may mắn và bảo vệ sức khỏe cho gia chủ."),
                        new ProductCollection("Cây Nha Đam", "Cây nha đam là biểu tượng của sức khỏe, chữa lành và sự tươi mới."),
                        new ProductCollection("Cây Vạn Niên Thanh", "Cây vạn niên thanh mang đến sự trường thọ, may mắn và hạnh phúc."),
                        new ProductCollection("Cây Nhất Mạt Hương", "Nhất mạt hương tượng trưng cho sự thanh tịnh, thư giãn và bình an."),
                    }
                },

                //love
                new GroupCollection()
                {
                    ProductCollection = new List<ProductCollection>{
                        new ProductCollection("Cây Lan Quân Tử", "Cây lan quân tử là biểu tượng của sự quân tử, đức tính cao thượng và tài lộc."),
                        new ProductCollection("Cây Trầu Bà", "Cây trầu bà mang lại may mắn, tài lộc và giúp cải thiện không khí trong nhà."),
                        new ProductCollection("Cây Hồng Môn", "Cây hồng môn là biểu tượng của sự giàu có, thịnh vượng và tình yêu."),
                        new ProductCollection("Cây Cẩm Nhung", "Cây cẩm nhung là biểu tượng của sự tươi mới, sinh động và sự biến hóa trong cuộc sống."),
                    }
                },

                //career
                new GroupCollection()
                {
                    ProductCollection = new List<ProductCollection>{
                        new ProductCollection("Cây Kim Ngân", "Cây kim ngân tượng trưng cho sự thịnh vượng, tài lộc và may mắn."),
                        new ProductCollection("Cây Tùng Bồng Lai", "Cây tùng bồng lai biểu tượng của sự bền vững, ổn định và trường thọ."),
                        new ProductCollection("Cây Phú Quý", "Cây phú quý là biểu tượng của sự giàu có, phú quý và thịnh vượng."),
                        new ProductCollection("Cây Lan Ý", "Lan ý là cây phong thủy, mang lại sự bình yên, thanh thản và cải thiện không khí trong nhà."),
                    }
                },

                //family
                new GroupCollection()
                {
                    ProductCollection = new List<ProductCollection>{
                        new ProductCollection("Cây Cọ Nhật", "Cọ nhật mang lại sự thanh thoát, quý phái và bình yên trong không gian sống."),
                        new ProductCollection("Cây Hương Thảo", "Cây hương thảo tượng trưng cho trí tuệ, sự nhớ nhung và lòng trung thành."),
                        new ProductCollection("Cây Xương Rồng", "Cây xương rồng tượng trưng cho sự kiên cường, sức mạnh và khả năng vượt qua khó khăn."),
                        new ProductCollection("Cây Đuôi Công", "Cây đuôi công mang lại sự tươi mới, sinh động và hài hòa trong không gian sống."),
                    }
                },


            };
        }
            
    }

}
