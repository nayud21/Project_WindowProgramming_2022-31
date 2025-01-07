using Microsoft.UI.Xaml;
using SellingTree.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using SellingTree.IDao;
using SellingTree.View;
using System.Collections.Specialized;
using SellingTree.Helper;
namespace SellingTree

{
    public class DetailItem : Detail, INotifyPropertyChanged
        { 
        public event PropertyChangedEventHandler PropertyChanged;

        public String ImageSource { get; set; }
        public String Name { get; set; }
        public DetailItem(Detail d)
        {
            var p = ProductHandle.findProductById(d.ProductID);
            ImageSource = p.ImageSource;
            Name = p.Name;
            ProductID = d.ProductID;
            Quantity = d.Quantity;
            Price = d.Price;
        }
    }
    class DetailViewModel : INotifyPropertyChanged
    {
        public FullObservableCollection<PageChanger> PageChangerButton { get; set; } = PageChanger.getPageChanger(1, 1);
        private List<DetailItem> ItemsData { get; set; }
        public FullObservableCollection<DetailItem> Items { get; set; }

        public int CurrentPage { get; set; }
        
        public DetailViewModel(List<Detail> details)
        {
            ItemsData = new List<DetailItem>();
            foreach (Detail item in details)
            {
                ItemsData.Add(new DetailItem(item));
            }
            Items = new FullObservableCollection<DetailItem>(ItemsData.Take(5));

        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private int MaxPage()
        {
            return (int)Math.Max(Math.Ceiling(ItemsData.Count / 5.0), 1);
        }
        private void LoadPage()
        {
            Items = PageChanger.LoadPage(CurrentPage, ItemsData);
        }
        private void CheckPage()
        {
            PageChangerButton = PageChanger.getPageChanger(CurrentPage, MaxPage());
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void ViewProduct(int id)
        {
            MainWindow.Instance.SetFrame(typeof(ProductView), ProductHandle.findProductById(id));
         
        }
        internal void ChangePage(String Page)
        {
            int ThisPage = int.Parse(Page);
            if (CurrentPage != ThisPage)
            {
                CurrentPage = ThisPage;
                LoadPage();
                CheckPage();
            }
        }

        internal void Review(int id)
        {
            MainWindow.Instance.SetFrame(typeof(ReviewsAndPayBack), ProductHandle.findProductById(id), 
                5);
        }
    }
}
