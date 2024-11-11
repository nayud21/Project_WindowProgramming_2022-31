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


namespace SellingTree
{
    internal class MainViewViewModel
    {
        public static MainViewViewModel instance = new MainViewViewModel();
        public List<Image> ImageList = new List<Image>();
        public List<Popup> Popups = new List<Popup>();
        public List<Button> ButtonList = new List<Button>();
        public ObservableCollection<Product> products { get; set; }
        public MainViewViewModel()
        {
            products = IDao.IDaoCollection.GetAllProduct();
        }
        public void Add(Image image)
        {
            ImageList.Add(image);
        }
        public void Add(Popup popup)
        {
            Popups.Add(popup);
        }
        public void Add(Button button)
        {
            ButtonList.Add(button);
        }

        internal void OnPointEntered(Image image)
        {
            for (int i = 0; i < ImageList.Count; i++)
                if (ImageList[i] == image)
                {
                    Popups[i].IsOpen = true;
                    ProductSelling productSelling = (ProductSelling)products[i];
                    image.Source = new BitmapImage(new Uri(productSelling.ImageSources[0]));
                }
        }

        internal void OnPointExited(Image image)
        {
            for (int i = 0; i < ImageList.Count; i++)
                if (ImageList[i] == image)
                {
                    Popups[i].IsOpen = false;
                    ProductSelling productSelling = (ProductSelling)products[i];
                    image.Source = new BitmapImage(new Uri(productSelling.ImageSource));
                }
        }

        internal void ButtonBuy_Clicked(Button button)
        {
            int index = 0;
            for (; index < ButtonList.Count; index++)
                if (ButtonList[index] == button)
                    break;

            ShopListViewModel.instance.Add(products[index]);
        }
        public void Reset()
        {
            ImageList.Clear();
            ButtonList.Clear();
            Popups.Clear();
        }

        internal void OpenProduct(Image image)
        {
            int index = 0;
            for (; index < ImageList.Count; index++)
                if (ImageList[index] == image)
                    break;

            MainWindow.Instance.SetFrame(typeof(ProductView), products[index]);
        }
    }
}
