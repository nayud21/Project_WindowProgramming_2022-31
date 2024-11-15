using Microsoft.UI.Xaml;
using SellingTree.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SellingTree
{
    class ShopListViewModel : INotifyPropertyChanged
    {
        public static ShopListViewModel instance = new();
        public FullObservableCollection<PageChanger> PageChangerButton { get; set; }
        = PageChanger.getPageChanger(1, 1);
        private List<MyShoppingItem> ItemsData { get; set;}
        public FullObservableCollection<MyShoppingItem> Items { get; set; }
        public int Count
        {
            get => ItemsData.Count;
        }
        public int TotalValue
        {
            get
            {
                int Sum = 0;
                foreach (var item in ItemsData)
                    if (item.IsChecked)
                        Sum += item.Cost;
                return Sum;
            }
        }
        public int CurrentPage { get; set; }
        public int SelectedCount
        {
            get
            {
                int selectedCount = 0;
                foreach (var item in ItemsData)
                    if (item.IsChecked)
                        selectedCount++;
                return selectedCount;
            }
        }

        public bool IsUserActivity = false;

        public bool _isSelected = false;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {

                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));

                if (IsUserActivity) return;

                IsUserActivity = true;
                foreach (var item in ItemsData)
                    item.IsChecked = value;

                IsUserActivity = false;
                LoadData();
            }
        }


        public ShopListViewModel()
        {
            Items = new FullObservableCollection<MyShoppingItem>();
            ItemsData = new List<MyShoppingItem>();
            CurrentPage = 1;
        }

        private void LoadPosition()
        {
            for (int i = 0; i < ItemsData.Count; i++)
                ItemsData[i].Position = i;
        }

        public void DeleteItem(String Tag)
        {
            int index = int.Parse(Tag);
            ItemsData.RemoveAt(index);

            LoadPosition();

            if (CurrentPage >= MaxPage())
            {
                CurrentPage = MaxPage();
                LoadPage();
            }

            CheckPage();
            LoadData();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void LoadData()
        {
            if (IsUserActivity) return;

            IsUserActivity = true;
            IsSelected = (SelectedCount == Count);
            IsUserActivity = false;

            OnPropertyChanged(nameof(SelectedCount));
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(TotalValue));
        }
        private int MaxPage()
        {
            return (int)Math.Max(Math.Ceiling(ItemsData.Count / 5.0), 1);
        }

        public void Add(Product product, int quantity = 1)
        {
            /*bool isAdded = false;
            foreach (var item in Items)
                if (item.product == product)
                {
                    item.Quantity += quantity;
                    isAdded = true;
                }

            if (!isAdded) */
            ItemsData.Add(new MyShoppingItem(product, quantity) { Position = Items.Count });

            if (CurrentPage == MaxPage())
                LoadPage();
            if (Count % 5 == 1)
                CheckPage();
            LoadData();
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

        internal void ViewProduct(String imageSource)
        {
            foreach (var item in Items)
                if (item.product.ImageSource == imageSource)
                {
                    MainWindow.Instance.SetFrame(typeof(ProductView), item.product);
                    break;
                }

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
    }
}
