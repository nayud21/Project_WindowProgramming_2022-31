using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.UI.Xaml.Controls;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SellingTree.Model;

namespace SellingTree
{
    class ShopListViewModel : INotifyPropertyChanged
    {
        public static ShopListViewModel instance = new ShopListViewModel();
        public ObservableCollection<MyShoppingItem> Items {  get; set; }

        public int _count;
        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        public int _selectedCount;
        public int SelectedCount
        {
            get => _selectedCount;
            set
            {
                _selectedCount = value;
                OnPropertyChanged(nameof(SelectedCount));
            }
        }

        public bool IsUserActivity = false;

        public bool _isSelected = false;
        public bool IsSelected {get => _isSelected;
            set {

                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));

                if (IsUserActivity) return;
                foreach (var item in Items)
                    item.IsChecked = value;
                OnPropertyChanged(nameof(IsSelected));
            } }

        private int _totalValue = 0;
        public int TotalValue { get => _totalValue; set {
                _totalValue = value; OnPropertyChanged(nameof(TotalValue));
            }
        }

        public ShopListViewModel()
        {
            Items = new ObservableCollection<MyShoppingItem>();
            SelectedCount = Count = 0;
        }

        private void LoadPosition()
        {
            for (int i=0; i<Items.Count; i++)
                Items[i].Position = i;
        }

        public void DeleteItem(String Tag)
        {
            int index = int.Parse(Tag);
            Items.RemoveAt(index);  
            
            LoadData();
            LoadPosition();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void LoadData()
        {
            Count = Items.Count;
            IsUserActivity = true;
            SelectedCount = 0;
            TotalValue = 0;
            IsSelected = true;

            foreach (var item in Items)
                if (item.IsChecked == true)
                {
                    SelectedCount++;
                    TotalValue += item.Cost;
                }
                else IsSelected = false;

            IsUserActivity = false;
        }

        public void Add(Product product, int quantity = 1)
        {
            bool isAdded = false;
            foreach (var item in Items)
                if (item.product == product)
                {
                    item.Quantity += quantity;
                    isAdded = true;
                }
            if (!isAdded) 
                Items.Add(new MyShoppingItem(product) { Position = Items.Count});

            LoadData();
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
    }
}
