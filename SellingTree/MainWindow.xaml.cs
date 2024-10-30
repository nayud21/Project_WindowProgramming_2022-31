using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SellingTree.View;
using System;
using System.Collections.Generic;
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
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
       static public MainWindow Instance;
       public MainWindow()
        {
            this.InitializeComponent();
            Frame1.Navigate(typeof(NavigationBarView));
            Frame2.Navigate(typeof(MainView));
            Instance = this;
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Content as Frame;
            if (rootFrame == null)
            {
                rootFrame = new Frame();
                Content = rootFrame;
            }
            rootFrame.Navigate(typeof(BlogPage));
        }
        private void chatButton_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Content as Frame;
            if (rootFrame == null)
            {
                rootFrame = new Frame();
                Content = rootFrame;
            }
            rootFrame.Navigate(typeof(ChatPage));

        }
        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }
        private void Window_Activated(object sender, WindowActivatedEventArgs args)
        {
            
        }
        public void SetFrame(Type type, Product product = null)
        {
            if (product == null) 
                Frame2.Navigate(type);
            else 
                Frame2.Content = new ProductView(product);
        }
       
    }
}
