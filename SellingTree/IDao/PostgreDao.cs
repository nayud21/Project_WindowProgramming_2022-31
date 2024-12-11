using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Npgsql;
using SellingTree.Model;

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

    }

    public class PostgreDaoUser
    {
        private readonly string _connectionString = "Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.thfctareaaikcsvjyrzn;Password=$#F3E*c5w5hcG*e;SslMode=Require;Trust Server Certificate=true";


        public async Task<User> ValidateUserAsync(string username, string password)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "SELECT * FROM users WHERE username = @username AND password = @password";
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
    }
    internal class PostgreDaoCollection : IDaoCollection
    {
        public static ObservableCollection<Product> GetAllProduct()
        {
            var connString = "Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.thfctareaaikcsvjyrzn;Password=$#F3E*c5w5hcG*e;SslMode=Require;Trust Server Certificate=true";
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
        static public List<Review> GetAllReviews(Product product)
        {
            {
                var connString = "Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.thfctareaaikcsvjyrzn;Password=$#F3E*c5w5hcG*e;SslMode=Require;Trust Server Certificate=true";
                var reviews = new List<Review>();
                try

                {


                    using (var conn = new NpgsqlConnection(connString))
                    {
                        conn.Open();
                        Debug.WriteLine("Kết nối thành công!");

                        // Thực thi một truy vấn mẫu
                        using (var cmd = new NpgsqlCommand($"SELECT users.name, users.avatar, date, content, score FROM product JOIN reviews ON product.name = @Name AND reviews.id = product.id JOIN users ON reviews.userid = users.userid; ", conn))
                        {

                            cmd.Parameters.AddWithValue("name", product.Name);
                            var reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                User user = new User()
                                {
                                    Name = reader.GetString(0),
                                    ImageLocation = "https://thfctareaaikcsvjyrzn.supabase.co/storage/v1/object/public/assets/Untitled%20folder/" + reader.GetString(1),
                                };
                                Review review = new Review()
                                {
                                    user = user,
                                    Date = reader.GetString(2),
                                    Content = reader.GetString(3),
                                    Score = reader.GetInt32(4),
                                };
                                reviews.Add(review);
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
                                OrderID = reader.GetInt32(0),
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
                    using (var cmd = new NpgsqlCommand($"SELECT * FROM detail WHERE orderid = {orderID};", conn))
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var orderDetail = new Detail
                            {
                                OrderID = reader.GetInt32(0),
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
        public void InsertDetail(Detail orderDetail)
        {
            var connString = "Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.thfctareaaikcsvjyrzn;Password=$#F3E*c5w5hcG*e;SslMode=Require;Trust Server Certificate=true";
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Debug.WriteLine("Kết nối thành công!");

                    // Thực thi một truy vấn mẫu
                    using (var cmd = new NpgsqlCommand($"INSERT INTO detail (orderid, productid, quantity, price) VALUES ({orderDetail.OrderID}, {orderDetail.ProductID}, {orderDetail.Quantity}, {orderDetail.Price});", conn))
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
}