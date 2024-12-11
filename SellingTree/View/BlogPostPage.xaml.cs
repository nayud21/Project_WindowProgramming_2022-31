using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SellingTree.IDao;
using SellingTree.Model;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SellingTree
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlogPostPage : Page
    {
        public BlogPostPage()
        {
            this.InitializeComponent();
        }
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            string description = ContentTextBox.Text;
            string imageLocation = "https://thfctareaaikcsvjyrzn.supabase.co/storage/v1/object/public/assets/Blog/blog01.jpg";
            int likes = 0;
            int views = 0;

            //Lưu vào cơ sở dữ liệu
            IDaoBlog dao = new PostgreDaoBlog();
            dao.InsertBlog(new Blog
            {
                Title = title,
                Description = description,
                ImageLocation = imageLocation,
                Likes = likes,
                Views = views
            });
            Frame.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Xử lý khi nhấn nút "Quay Lại"
            Frame.GoBack();
        }
    }
}
