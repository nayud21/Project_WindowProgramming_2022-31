using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Npgsql;
using SellingTree.Model;
using System.IO;

namespace SellingTree.IDao
{
    public class PostgreDaoBlog : IDaoBlog
    {

        public List<Blog> GetBlogs()

        {
            var connString = GetConnectionString();
            var blogs = new List<Blog>();
            try

            {


                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    // Thực thi một truy vấn mẫu
                    using (var cmd = new NpgsqlCommand("SELECT * FROM blog;", conn))
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var blog = new Blog
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Description = reader.GetString(2),
                                ImageLocation = reader.GetString(3),
                                Likes = reader.GetInt32(4),
                                Views = reader.GetInt32(5)
                            };
                            blogs.Add(blog);
                        }
                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }
            return blogs;
        }
        public void InsertBlog(Blog blog)
        {
            var connString = GetConnectionString();
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    // Thực thi một truy vấn mẫu
                    using (var cmd = new NpgsqlCommand($"INSERT INTO blog (title, description, imagelocation, likes, views) VALUES ('{blog.Title}', '{blog.Description}', '{blog.ImageLocation}', {blog.Likes}, {blog.Views});", conn))
                    {
                        cmd.ExecuteNonQuery();

                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }
        }
        private static string GetConnectionString()
        {
            var connectionString = "Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.thfctareaaikcsvjyrzn;Password=$#F3E*c5w5hcG*e;SslMode=Require;Trust Server Certificate=true";
            return connectionString;
        }
        public void DeleteBlog(Blog blog)
        {
            var connString = GetConnectionString();
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    // Thực thi một truy vấn mẫu
                    using (var cmd = new NpgsqlCommand($"DELETE FROM blog WHERE blogid = '{blog.Id}';", conn))
                    {
                        cmd.ExecuteNonQuery();

                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }
        }

    }

    public class PostgreDaoUser
    {
        private readonly string _connectionString = "Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.thfctareaaikcsvjyrzn;Password=$#F3E*c5w5hcG*e;SslMode=Require;Trust Server Certificate=true";


        public async Task<User> ValidateUserAsync(string username, string password)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "UPDATE users SET islogin = true WHERE username=@username AND password=@password AND islogin = false RETURNING *";
            using var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("password", password);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                var user = new User
                {
                    UserId = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Password = reader.GetString(2),
                    Name = reader.GetString(3),
                    ImageLocation = "https:/" +
                                "/thfctareaaikcsvjyrzn.supabase.co/storage/v1/object/public/assets/avt/" + reader.GetString(4),
                    Type = reader.GetString(5)

                };
                return user;

            }
            connection.Close();
            NpgsqlConnection.ClearPool(connection);
            return null;
        }

        public void Logout(int userId)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            var query = "UPDATE users SET islogin = false WHERE userid=@userid";
            using var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("userid", userId);
            command.ExecuteNonQuery();
            connection.Close();
            NpgsqlConnection.ClearPool(connection);
        }
        public void InsertUser(User user)
        {
            var connString = _connectionString;
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    using (var cmd = new NpgsqlCommand($"INSERT INTO users (username, password, name, avatar, type,islogin) VALUES ('{user.Username}', '{user.Password}', '{user.Name}', '{user.ImageLocation}', '{user.Type}','FALSE');", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }
        }
    }
    internal class PostgreDaoCollection : IDaoCollection
    {
        static String connString = "Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.thfctareaaikcsvjyrzn;Password=$#F3E*c5w5hcG*e;SslMode=Require;Trust Server Certificate=true";
        public static ObservableCollection<Product> GetAllProduct()
        {
            
            var products = new ObservableCollection<Product>();
            try

            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    // Thực thi một truy vấn mẫu
                    using (var cmd = new NpgsqlCommand("SELECT * FROM product ORDER BY id;", conn))
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var product = new Product()
                            {
                                PID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2),
                                ImageSource = reader.GetString(3),
                                Price = reader.GetInt32(4),
                                Sold = reader.GetInt32(5),
                                Stored = reader.GetInt32(6),
                            };
                            products.Add(product);
                        }

                        conn.Close();
                        NpgsqlConnection.ClearPool(conn);
                    }
                }

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT * FROM imagesources;", conn))
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int ID = reader.GetInt32(0);
                            String imagesource = "https:/" +
                                "/thfctareaaikcsvjyrzn.supabase.co/storage/v1/object/public/assets/Untitled%20folder/"
                                + reader.GetString(1);

                            if (products[ID - 1].ImageSources == null)
                                products[ID - 1].ImageSources = new ObservableCollection<String>();
                            products[ID - 1].ImageSources.Add(imagesource);


                        }
                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }


            return products;
        }
        public static Tuple<FullObservableCollection<Product>, int> GetProductAtPage(int v = 1)
        {
            var connString = "Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.thfctareaaikcsvjyrzn;Password=$#F3E*c5w5hcG*e;SslMode=Require;Trust Server Certificate=true";
            var products = new FullObservableCollection<Product>();
            int result = 0;
            try

            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    // Adjust the SQL query to use the CTE and LEAST function
                    string query = @"
                    WITH total_products AS (
                    SELECT COUNT(*) AS total_count
                    FROM product),
                    paginated_products AS (
                    SELECT *,
                    ROW_NUMBER() OVER (ORDER BY id) AS row_num
                    FROM product
                    )
                    SELECT p.*, tp.total_count
                    FROM paginated_products p
                    CROSS JOIN total_products tp
                    WHERE p.row_num > least((@value-1)*16, ((tp.total_count -1)/16*16))
                    ORDER BY p.id
                    FETCH NEXT 16 ROWS ONLY;";

                    // Create the command with the parameter for page number `x`
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@value", v);
                        var reader = cmd.ExecuteReader();

                        if (!reader.HasRows)
                        {
                            conn.Close();
                            NpgsqlConnection.ClearPool(conn);
                            return new Tuple<FullObservableCollection<Product>, int>
                                (new FullObservableCollection<Product>(), 0);
                        }

                        while (reader.Read())
                        {
                            var product = new Product()
                            {
                                PID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2),
                                ImageSource = reader.GetString(3),
                                Price = reader.GetInt32(4),
                                Sold = reader.GetInt32(5),
                                Stored = reader.GetInt32(6),
                            };
                            if (result == 0)
                                result = reader.GetInt32(8);

                            products.Add(product);
                        }

                        conn.Close();
                        NpgsqlConnection.ClearPool(conn);
                    }
                }

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    int index = 0;
                    using (var cmd = new NpgsqlCommand("SELECT * FROM imagesources ORDER BY id;", conn))
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int ID = reader.GetInt32(0);

                            while (index < products.Count && products[index].PID != ID)
                                index++;

                            if (index == products.Count)
                                break;
                            String imagesource = "https:/" +
                                "/thfctareaaikcsvjyrzn.supabase.co/storage/v1/object/public/assets/Untitled%20folder/"
                                + reader.GetString(1);

                            if (products[index].ImageSources == null)
                                products[index].ImageSources = new ObservableCollection<String>();
                            products[index].ImageSources.Add(imagesource);


                        }
                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }
            return new Tuple<FullObservableCollection<Product>, int>(products, result);
        }

        static public List<Review> GetAllReviews(Product product)
        {
            {
                var reviews = new List<Review>();
                try
                {
                    using (var conn = new NpgsqlConnection(connString))
                    {
                        conn.Open();
                        Debug.WriteLine("Kết nối thành công!");

                        // Thực thi một truy vấn mẫu
                        using (var cmd = new NpgsqlCommand($"SELECT u.name, u.avatar, r.date, content, score, images, mode FROM reviews r JOIN users u ON r.id = @id AND r.userid = u.userid LEFT JOIN reviewimages ri ON ri.userid = r.userid AND ri.id= r.id AND ri.date = r.date ; ", conn))
                        {

                            cmd.Parameters.AddWithValue("id", product.PID);
                            var reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                
                                User user = new User()
                                {
                                    Name = reader.GetString(0),
                                    ImageLocation = "https://thfctareaaikcsvjyrzn.supabase.co/storage/v1/object/public/assets/avt/" + reader.GetString(1),
                                };

                                if (reader.GetInt32(6) / 4 /2 == 1)
                                {
                                    user.Name = "Người dùng ẩn danh";
                                    user.ImageLocation = "";
                                }   
                                Review review = new Review()
                                {
                                    user = user,
                                    Date = reader.GetString(2),
                                    Content = reader.GetString(3),
                                    Score = reader.GetInt32(4),
                                };
                                String temp = reader.GetString(5);
                                MediaOrImage m = new MediaOrImage("https://thfctareaaikcsvjyrzn.supabase.co/storage/v1/object/public/assets/Reviews/" +
                                                                        temp);
                                if (temp[^3..] == "mp4")
                                {
                                    m.isVideo = 1; m.isImage = 0;
                                }
                                var existedReview = reviews.FirstOrDefault(r => r.user.Name == user.Name && r.Date == review.Date);
                                if (existedReview != null)
                                {
                                    existedReview.MediaList.Add(m);
                                }
                                else
                                {
                                    review.MediaList = new List<MediaOrImage> { m };
                                    reviews.Add(review);
                                }
                            }
                        }
                        conn.Close();
                        NpgsqlConnection.ClearPool(conn);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi kết nối: {ex.Message}");
                }
                return reviews;
            }
        }


        public static async Task AddReview(User user, Product p, String content, List<MediaOrImage> m, int Value, int Mode)
        {
            var reviews = new List<Review>();
            try
            {
                var date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    // Thực thi một truy vấn mẫu
                    using (var cmd = new NpgsqlCommand("INSERT INTO reviews (userid, id, date, content, score, mode) VALUES (@userId, @PId, @date, @content, @Score, @mode);", conn))
                    {


                        cmd.Parameters.AddWithValue("userId", user.UserId);
                        cmd.Parameters.AddWithValue("date", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                        cmd.Parameters.AddWithValue("userId", user.UserId);
                        cmd.Parameters.AddWithValue("date", date);
                        cmd.Parameters.AddWithValue("PId", p.PID);
                        cmd.Parameters.AddWithValue("content", content);
                        cmd.Parameters.AddWithValue("Score", Value);
                        cmd.Parameters.AddWithValue("mode", Mode);
                        var reader = await cmd.ExecuteNonQueryAsync();
                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    var command = "INSERT INTO reviewimages(userid, id, date, images) VALUES ";

                    foreach (var item in m)
                    {
                        command += $"({user.UserId},{p.PID}, \'{date}\', \'{Path.GetFileName(item.content)}\'),";
                    }

                    command = command[0..^1] + ';';

                    using (var cmd = new NpgsqlCommand(command, conn))
                    {
                        var reader = await cmd.ExecuteNonQueryAsync();
                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }
        }

    }
    public class PostgreDaoOrder : IDaoOrder
    {
        public List<Order> GetOrders()
        {
            var connString = "Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.thfctareaaikcsvjyrzn;Password=$#F3E*c5w5hcG*e;SslMode=Require;Trust Server Certificate=true";
            var orders = new List<Order>();
            try

            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    // Thực thi một truy vấn mẫu
                    using (var cmd = new NpgsqlCommand("SELECT * FROM orderproduct;", conn))
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var order = new Order
                            {
                                OrderID = reader.GetInt32(0),
                                UserID = reader.GetInt32(1),
                                OrderDate = reader.GetDateTime(2),
                                TotalPrice = reader.GetInt32(3),
                            };
                            orders.Add(order);
                        }
                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }
            return orders;

        }
        public List<Order> GetOrdersForCustomer(int customerID)
        {
            var connString = "Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.thfctareaaikcsvjyrzn;Password=$#F3E*c5w5hcG*e;SslMode=Require;Trust Server Certificate=true";
            var orders = new List<Order>();
            try

            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    // Thực thi một truy vấn mẫu
                    using (var cmd = new NpgsqlCommand($"SELECT * FROM orderproduct WHERE userid = {customerID};", conn))
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var order = new Order
                            {
                                OrderID = reader.GetInt32(0),
                                UserID = reader.GetInt32(1),
                                OrderDate = reader.GetDateTime(2),
                                TotalPrice = reader.GetInt32(3),
                            };
                            orders.Add(order);
                        }
                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }
            return orders;
        }
        public void InsertOrder(Order order)
        {
            var connString = "Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.thfctareaaikcsvjyrzn;Password=$#F3E*c5w5hcG*e;SslMode=Require;Trust Server Certificate=true;Timeout=60;CommandTimeout=120";
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    // Thực thi một truy vấn mẫu
                    using (var cmd = new NpgsqlCommand($"INSERT INTO orderProduct (userid, time, totalprice) VALUES ({order.UserID}, '{order.OrderDate}', {order.TotalPrice});", conn))
                    {

                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }
            }
            catch (Npgsql.NpgsqlException ex)
            {
                Console.WriteLine($"Lỗi PostgreSQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }

        }
    }
    public class PostgreDaoDetail : IDaoDetail
    {
        public List<Detail> GetDetails()
        {
            var connString = "Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.thfctareaaikcsvjyrzn;Password=$#F3E*c5w5hcG*e;SslMode=Require;Trust Server Certificate=true";
            var orderDetails = new List<Detail>();
            try

            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    // Thực thi một truy vấn mẫu
                    using (var cmd = new NpgsqlCommand("SELECT * FROM detail;", conn))
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var orderDetail = new Detail
                            {
                                //OrderID = reader.GetInt32(0),
                                ProductID = reader.GetInt32(1),
                                Quantity = reader.GetInt32(2),
                                Price = reader.GetInt32(3),
                            };
                            orderDetails.Add(orderDetail);
                        }
                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }
            return orderDetails;
        }
        public List<Detail> GetDetailsForOrder(int orderID)
        {
            var connString = "Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.thfctareaaikcsvjyrzn;Password=$#F3E*c5w5hcG*e;SslMode=Require;Trust Server Certificate=true";
            var orderDetails = new List<Detail>();
            try

            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    // Thực thi một truy vấn mẫu
                    using (var cmd = new NpgsqlCommand($"SELECT d.* FROM detail d JOIN orderproduct o ON o.userid = d.userid AND o.time = d.date WHERE id = {orderID};", conn))
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var orderDetail = new Detail
                            {
                                //OrderID = reader.GetInt32(0),
                                ProductID = reader.GetInt32(0),
                                Quantity = reader.GetInt32(1),
                                Price = reader.GetInt32(2),
                            };
                            orderDetails.Add(orderDetail);
                        }
                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }
            return orderDetails;
        }
        public void InsertDetail(List<Detail> orderDetail, User user, DateTime date)
        {
            var connString = "Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.thfctareaaikcsvjyrzn;Password=$#F3E*c5w5hcG*e;SslMode=Require;Trust Server Certificate=true";
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    String command = "INSERT INTO detail (productid, userid, date, quantity, price) VALUES";

                    foreach (var detail in orderDetail)
                        command += $"({detail.ProductID}, {user.UserId}, '{date}', {detail.Quantity}, {detail.Price}),";

                    command = command[0..^1] + ';';

                    // Thực thi một truy vấn mẫu
                    using (var cmd = new NpgsqlCommand(command, conn))
                    {
                        cmd.ExecuteNonQuery();

                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }
        }
    }
    public class PostgreDaoMessage : IDaoMessage
    {
        public List<Message> GetMessages()
        {
            var connString = "Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.thfctareaaikcsvjyrzn;Password=$#F3E*c5w5hcG*e;SslMode=Require;Trust Server Certificate=true";
            var messages = new List<Message>();
            try

            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    // Thực thi một truy vấn mẫu
                    using (var cmd = new NpgsqlCommand("SELECT * FROM messages ORDER BY timestamp", conn))
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var message = new Message
                            {
                                Sender = reader.GetString(0),
                                Content = reader.GetString(1),
                                Timestamp = reader.GetDateTime(2),
                                CustomerID = reader.GetInt32(3)
                            };
                            messages.Add(message);
                        }
                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }
            return messages;
        }
        public List<Message> GetMessagesForCustomer(int customerID)
        {
            var connString = "Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.thfctareaaikcsvjyrzn;Password=$#F3E*c5w5hcG*e;SslMode=Require;Trust Server Certificate=true";
            var messages = new List<Message>();
            try

            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    // Thực thi một truy vấn mẫu
                    using (var cmd = new NpgsqlCommand($"SELECT * FROM messages WHERE messid = {customerID} ORDER BY timestamp", conn))
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var message = new Message
                            {
                                Sender = reader.GetString(0),
                                Content = reader.GetString(1),
                                Timestamp = reader.GetDateTime(2),
                            };
                            messages.Add(message);
                        }
                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }
            return messages;
        }
        public Dictionary<int, List<Message>> GetMessagesGroupedByCustomer()
        {
            var connString = GetConnectionString();
            var messagesGroupedByCustomer = new Dictionary<int, List<Message>>();
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    using (var cmd = new NpgsqlCommand("SELECT * FROM messages ORDER BY timestamp", conn))
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var message = new Message
                            {
                                Sender = reader.GetString(0),
                                Content = reader.GetString(1),
                                Timestamp = reader.GetDateTime(2),
                                CustomerID = reader.GetInt32(3),
                                Name = reader.GetString(4)
                            };

                            if (!messagesGroupedByCustomer.ContainsKey(message.CustomerID))
                            {
                                messagesGroupedByCustomer[message.CustomerID] = new List<Message>();
                            }
                            messagesGroupedByCustomer[message.CustomerID].Add(message);
                        }
                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }
            return messagesGroupedByCustomer;
        }
        public void InsertMessage(Message message)
        {
            var connString = GetConnectionString();
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    using (var cmd = new NpgsqlCommand($"INSERT INTO messages (sender, content, timestamp, messid, name) VALUES ('{message.Sender}', '{message.Content}', '{message.Timestamp}', {message.CustomerID}, '{message.Name}');", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }
        }
        private static string GetConnectionString()
        {
            return "Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.thfctareaaikcsvjyrzn;Password=$#F3E*c5w5hcG*e;SslMode=Require;Trust Server Certificate=true";
        }
    }

    public class PostgreDaoProduct : IDaoProduct
    {
        public void InsertProduct(Product product)
        {
            var connString = GetConnectionString();
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    using (var cmd = new NpgsqlCommand($"INSERT INTO product (name, description, imagesource, price, sold, stored) VALUES ('{product.Name}', '{product.Description}', '{product.ImageSource}', {product.Price}, {product.Sold}, {product.Stored});", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }
        }
        public void DeleteProduct(Product product)
        {
            var connString = GetConnectionString();
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    // Thực thi một truy vấn mẫu
                    using (var cmd = new NpgsqlCommand($"DELETE FROM product WHERE id = {product.PID};", conn))
                    {
                        cmd.ExecuteNonQuery();

                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }

        }
        public void UpdateProduct(Product product)
        {
            var connString = GetConnectionString();
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    // Thực thi một truy vấn mẫu
                    using (var cmd = new NpgsqlCommand($"UPDATE product SET name = '{product.Name}', description = '{product.Description}',imagesource = '{product.ImageSource}', price = {product.Price},sold ={product.Sold}, stored = {product.Stored} WHERE id = {product.PID};", conn))
                    {
                        cmd.ExecuteNonQuery();

                    }
                    conn.Close();
                    NpgsqlConnection.ClearPool(conn);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }
        }
        public string GetConnectionString()
        {
            return "Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.thfctareaaikcsvjyrzn;Password=$#F3E*c5w5hcG*e;SslMode=Require;Trust Server Certificate=true";
        }
    }
    public class SupabaseStorageService
    {
        private readonly HttpClient _httpClient;
        public static SupabaseStorageService instance = null;

        public static SupabaseStorageService getInstance()
        {
            if (instance == null)
                instance = new SupabaseStorageService();
            return instance;
        }
        public SupabaseStorageService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://thfctareaaikcsvjyrzn.supabase.co")
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InRoZmN0YXJlYWFpa2Nzdmp5cnpuIiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTczMjE1MDAzNiwiZXhwIjoyMDQ3NzI2MDM2fQ.z2cvnUcgX_5aOtDQ-E1Jj7UOqvywRenIsE6DPmhLO0U");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async void UploadImageAsync(string filePath, string FolderName, string NewName = null)
        {
            if (NewName == null)
            {
                NewName = Path.GetFileName(filePath);
            }
            var fileContent = new ByteArrayContent(await File.ReadAllBytesAsync(filePath));
            var temp = Path.GetExtension(filePath);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue($"image/{temp[1..^0]}"); // Adjust MIME type as necessary

            try
            {
                var response = await _httpClient.PostAsync($"storage/v1/object/assets/{FolderName}/{NewName}", fileContent);
                var responseContent = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException ex)
            {

            }
        }
        public async void UploadVideoAsync(string filePath, string FolderName, string NewName = null)
        {
            if (NewName == null)
            {
                NewName = Path.GetFileName(filePath);
            }
            var fileContent = new ByteArrayContent(await File.ReadAllBytesAsync(filePath));
            var temp = Path.GetExtension(filePath);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue($"video/{temp[1..^0]}"); // Adjust MIME type as necessary

            try
            {
                var response = await _httpClient.PostAsync($"storage/v1/object/assets/{FolderName}/{NewName}", fileContent);
                var responseContent = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException ex)
            {

            }
        }
    }
}

