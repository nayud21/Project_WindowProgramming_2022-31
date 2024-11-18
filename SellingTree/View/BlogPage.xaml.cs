using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SellingTree.View;
using SellingTree.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SellingTree
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlogPage : Page
    {
        public BlogViewModel ViewModel { get; set; }

        public BlogPage()
        {
            this.InitializeComponent();
            ViewModel = new BlogViewModel();
            this.DataContext = ViewModel;
            Control4.ItemsSource = ViewModel.Blogs;
        }
        private void PostButton_Click(object sender, RoutedEventArgs e)
        {
            // Xử lý khi nhấn nút "Đăng Bài"
            Frame.Navigate(typeof(BlogPostPage));
            

        }
        private void BackMainWindow_Click(object sender, RoutedEventArgs e)
        {
          Frame.GoBack();
        }

  
    }
}
