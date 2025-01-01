using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Navigation;
using SellingTree.Model;
using System.ComponentModel;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SellingTree
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainView : Page
    {
        public MainView()
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

        private void PageChangerButton_Clicked(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (b.Style == PageChanger.accentButtonStyle || b.Content.ToString() == "...")
                return;
            MainViewViewModel.instance.ChangePage(b.Content as string);
        }
    }
}
