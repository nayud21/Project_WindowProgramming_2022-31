using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellingTree.Model;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml.Media;
using System.ComponentModel;


namespace SellingTree
{
    internal class MainViewViewModel : INotifyPropertyChanged
    {
        public static MainViewViewModel instance = new MainViewViewModel();

        public List<Popup> Popups = new List<Popup>();

        public event PropertyChangedEventHandler PropertyChanged;

        public FullObservableCollection<Product> products { get; set; }

        public int CurrentPage { get; set; }

        public FullObservableCollection<PageChanger> PageChangerButton { get; set; }
        public MainViewViewModel()
        {
            var result = IDao.IDaoCollection.GetProductAtPage(1);
            products = result.Item1;
            PageChangerButton = PageChanger.getPageChanger(1, (int)Math.Ceiling(result.Item2/16.0));
            Popups = new List<Popup>();
                       
        }
        public void Add(Popup popup)
        {
            Popups.Add(popup);
        }

        internal void OnPointEntered(Image image)
        {
            var ImageSource = image.Tag as String;
            
            try
            {
                for (int i = 0; i < products.Count; i++)
                    if (products[i].ImageSource == ImageSource)
                    {
                        Popups[i].IsOpen = true;
                        image.Source = new BitmapImage(new Uri(products[i].ImageSources[1]));
                    }
            }
            catch (Exception) { }
        }

        internal void OnPointExited(Image image)
        {
            var ImageSource = image.Tag as String;

            try
            {
                for (int i = 0; i < products.Count; i++)
                    if (products[i].ImageSource == ImageSource)
                    {
                        Popups[i].IsOpen = false;
                        image.Source = new BitmapImage(new Uri(products[i].ImageSource));
                    }
            }
            catch (Exception) { }
        }

        internal void ButtonBuy_Clicked(Button button)
        {
            int index = 0;
            String ImageSource = (button.Tag).ToString();
            for (; index < products.Count; index++)
                if (products[index].ImageSource == ImageSource)
                {

                    ShopListViewModel.instance.Add(products[index]);
                    return;
                }

        }
        public void Reset()
        {
            Popups.Clear();
        }

        internal void OpenProduct(Image image)
        {
            int index = 0;
            String ImageSource = (image.Tag).ToString();
            for (; index < products.Count; index++)
                if (products[index].ImageSource == ImageSource)
                {

                    MainWindow.Instance.SetFrame(typeof(ProductView), products[index]);
                    return;
                }

        }

        internal void ChangePage(String ButtonName)
        {
            var result = IDao.PostgreDaoCollection.GetProductAtPage(int.Parse(ButtonName));
            products = result.Item1;
            PageChangerButton = PageChanger.getPageChanger(int.Parse(ButtonName), (int)Math.Ceiling(result.Item2/16.0));
        }
    }
}
