using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }
            return blogs;
        }
        private static string GetConnectionString()
        {
            var connectionString = "Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.thfctareaaikcsvjyrzn;Password=$#F3E*c5w5hcG*e;SslMode=Require;Trust Server Certificate=true";
            return connectionString;
        }

    }
}