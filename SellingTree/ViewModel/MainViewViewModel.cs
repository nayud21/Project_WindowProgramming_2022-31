using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media.Imaging;
using SellingTree.Model;
namespace SellingTree
{
    internal class MainViewViewModel
    {
        public static MainViewViewModel instance = new MainViewViewModel();
        public List<Popup> Popups = new List<Popup>();
        public ObservableCollection<Product> products { get; set; }
        public MainViewViewModel()
        {
            products = IDao.IDaoCollection.GetAllProduct();
        }
        public void Add(Popup popup)
        {
            Popups.Add(popup);
        }

        internal void OnPointEntered(Image image)
        {
            String productName = image.Tag.ToString();
            for (int index = 0; index < products.Count; index++)
                if (products[index].Name == productName)
                {
                    Popups[index].IsOpen = true;
                    Uri newUri = new Uri(products[index].ImageSources[0]);
                    image.Source = new BitmapImage(newUri);
                    break;
                }
        }

        internal void OnPointExited(Image image)
        {
            String productName = image.Tag.ToString();
            for (int index = 0; index < products.Count; index++)
                if (products[index].Name == productName)
                {
                    Popups[index].IsOpen = false;
                    Uri newUri = new Uri(products[index].ImageSource);
                    image.Source = new BitmapImage(newUri);
                    break;
                }
        }

        internal void ButtonBuy_Clicked(String productName)
        {
            int index = 0;
            for (; index < products.Count; index++)
                if (products[index].Name == productName)
                    break;

            ShopListViewModel.instance.Add(products[index]);
        }
        public void Reset()
        {
            Popups.Clear();
        }

        internal void OpenProduct(String productName)
        {
            int index = 0;
            for (; index < products.Count; index++)
                if (products[index].Name == productName)
                    break;

            MainWindow.Instance.SetFrame(typeof(ProductView), products[index]);
        }
    }
}
