using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
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
    public sealed partial class MainViewAdmin : Page
    {
        public MainViewAdmin()
        {
            MainViewViewModel.instance.Reset();
            this.InitializeComponent();
            DataContext = MainViewViewModel.instance;

        }


        private void Popup_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            MainViewViewModel.instance.Add(sender as Popup);
        }

        private void OnPointerEntered(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            MainViewViewModel.instance.OnPointEntered(sender as Image);
        }

        private void OnPointerExited(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            MainViewViewModel.instance.OnPointExited(sender as Image);
        }

        private void ButtonBuy_Clicked(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            MainViewViewModel.instance.ButtonBuy_Clicked(sender as Button);
        }

        private void Image_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            MainViewViewModel.instance.OpenProduct(sender as Image);
        }
    }
}
