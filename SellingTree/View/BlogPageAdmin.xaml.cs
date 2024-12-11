using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SellingTree.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SellingTree.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlogPageAdmin : Page
    {
        public BlogViewModel ViewModel { get; set; }

        public BlogPageAdmin()
        {
            this.InitializeComponent();
            ViewModel = new BlogViewModel();
            this.DataContext = ViewModel;
            Control4.ItemsSource = ViewModel.Blogs;
        }
        private void BackMainWindow_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Xử lý khi nhấn nút "Xóa"
            // Lấy ra blog cần xóa

            var blog = (sender as Button).DataContext as Model.Blog;
            // Xử lý xóa blog trong database
            SellingTree.IDao.IDaoBlog dao = new SellingTree.IDao.PostgreDaoBlog();
            ViewModel.Blogs.Remove(blog);
            dao.DeleteBlog(blog);
            
            

            


        }
    }
}
