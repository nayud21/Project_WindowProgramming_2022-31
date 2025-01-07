using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Windowing;
using Windows.Storage;
using SellingTree.View;
using SellingTree.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI;
using WinRT.Interop; // Add this for WindowNative

namespace SellingTree
{
    public sealed partial class MainWindow : Window
    {
        static public MainWindow Instance;
        private Microsoft.UI.Windowing.AppWindow appWindow;

        public MainWindow()
        {
            this.InitializeComponent();
            this.Title = "Selling Tree";

            Frame1.Navigate(typeof(NavigationBarView));
            Frame2.Navigate(typeof(MainView));

            Instance = this;
            // 
            var hwnd = WindowNative.GetWindowHandle(this);

            // 
            var windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
            var appWindow = AppWindow.GetFromWindowId(windowId);

            // 
            appWindow.SetIcon("Assets/logo.ico"); // 
        }

        private void SetWindowIcon(string iconPath)
        {
            var hwnd = WindowNative.GetWindowHandle(this);
            appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(Win32Interop.GetWindowIdFromWindow(hwnd));
            if (appWindow != null)
            {
                appWindow.SetIcon(iconPath);
            }
        }

        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void Window_Activated(object sender, WindowActivatedEventArgs args)
        {

        }

        public Type GetFrame() => Frame2.Content as Type;

        public void SetFrame(Type type, Product product = null, float Average = -1, List<Detail> details = null)
        {
            if (details != null)
                Frame2.Content = new DetailView(details);
            else if (Average != -1)
                Frame2.Content = new ReviewsAndPayBack(product, Average);
            else if (product == null)
                Frame2.Navigate(type);
            else
                Frame2.Content = new ProductView(product);
        }

        private void Window_Closed(object sender, WindowEventArgs args)
        {
            NavigationBarView.instance.logOut_Click(sender, new RoutedEventArgs());
        }
    }
}
