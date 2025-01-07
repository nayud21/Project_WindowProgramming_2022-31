using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SellingTree.Model;
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
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class DetailView : Page
    {
        DetailViewModel viewModel;
        public DetailView(List<Detail> details)
        {
            this.InitializeComponent();
            viewModel = new DetailViewModel(details);
            DataContext = viewModel;
        }

        private void PageChangerButton_Clicked(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;
            if (button.Content.ToString() == "..." || button.Style == PageChanger.accentButtonStyle)
                return;
            viewModel.ChangePage(button.Content as String);
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var image = sender as Image;
            viewModel.ViewProduct(int.Parse(image.Tag as String));
        }

        private void Review(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int id = int.Parse(button.Tag.ToString());
            viewModel.Review(id);
        }
    }
}
