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
using SellingTree.Model;
using Microsoft.UI.Xaml.Media.Imaging;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SellingTree
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GroupCollectionDetails : Page
    {

        private GroupCollection Collection { get; set; }

        public GroupCollectionDetails()
        {
            this.InitializeComponent();

            image1.Opacity = 1.0;
            image1.Height = 300;
            image1.Width = 300;

            image2.Opacity = 0.3;
            image2.Height = 250;
            image2.Width = 250;

            image3.Opacity = 0.3;
            image3.Height = 250;
            image3.Width = 250;

            image4.Opacity = 0.3;
            image4.Height = 250;
            image4.Width = 250;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Collection = e.Parameter as GroupCollection;


            description.Text = Collection.ProductCollection[0].Product.Description.ToString();
            meaning.Text = Collection.ProductCollection[0].Meaning.ToString();   

        }

        private void Image_PointerPressed(object sender, PointerRoutedEventArgs e)
        {

            image1.Opacity = 0.3;
            image1.Height = 250;
            image1.Width = 250;

            image2.Opacity = 0.3;
            image2.Height = 250;
            image2.Width = 250;

            image3.Opacity = 0.3;
            image3.Height = 250;
            image3.Width = 250;

            image4.Opacity = 0.3;
            image4.Height = 250;
            image4.Width = 250;

            var image = sender as Image;
            var tag = int.Parse(image.Tag.ToString());

            image.Opacity = 1.0;
            image.Height = 300;
            image.Width = 300;

            description.Text = Collection.ProductCollection[tag].Product.Description;
            meaning.Text = Collection.ProductCollection[tag].Meaning;

        }
    }
}
