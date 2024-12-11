using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SellingTree.IDao;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using SellingTree.ViewModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SellingTree
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CollectionPage : Page
    {

        GroupCollectionViewModel CollectionViewModel = new GroupCollectionViewModel();
        

        Dictionary<String, int> hashGroup = new Dictionary<String, int>
        {
            {"Spring", 0 },
            {"Summer", 1 },
            {"Autumn", 2 },
            {"Winter", 3 },
            {"Wealth", 4 },
            {"Health", 5 },
            {"Love", 6 },
            {"Career", 7 },
            {"Family", 8 },
        };

        public CollectionPage()
        {
            this.InitializeComponent();
        }

        private void MoreInformationButton_Click(object sender, RoutedEventArgs e)
        {
            Button moreInformation = sender as Button;
            string name = moreInformation.Name;

            int id = int.Parse(name[name.Length - 1].ToString());

            Frame.Navigate(typeof(GroupCollectionDetails), CollectionViewModel.GroupCollections[id]);
        }
    }
}