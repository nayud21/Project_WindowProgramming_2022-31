using Microsoft.UI.Xaml;
using SellingTree.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using SellingTree.IDao;
using SellingTree.View;
using Microsoft.UI.Xaml.Controls;
namespace SellingTree

{
    class ShopListViewModel : INotifyPropertyChanged
    {
        public static ShopListViewModel instance = new ShopListViewModel();
        public FullObservableCollection<PageChanger> PageChangerButton { get; set; } = PageChanger.getPageChanger(1,1);
        private List<MyShoppingItem> ItemsData { get; set; }
        public FullObservableCollection<MyShoppingItem> Items { get; set; }

        public int Count => ItemsData.Count;
        public int CurrentPage { get; set; }
        public int SelectedCount
        {
            get
            {
                int Counting = 0;
                foreach(var item in ItemsData)
                    if(item.IsChecked) Counting++;
                return Counting;
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

                OnPropertyChanged(nameof(SelectedCount));
                OnPropertyChanged(nameof(TotalValue));
                IsUserActivity = false;

                LoadData();
            }
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
        public ShopListViewModel()
        {
            Items = new FullObservableCollection<MyShoppingItem>();
            ItemsData = new List<MyShoppingItem>();
            CurrentPage = 1;
        }
        private void LoadPosition()
        {
            for (int i = 0; i < Count; i++)
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
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(TotalValue));
            OnPropertyChanged(nameof(SelectedCount));
            if (IsUserActivity) return;
            IsUserActivity = true;
            IsSelected = true;

            foreach (var item in ItemsData)
                if (item.IsChecked != true)
                    IsSelected = false;

            IsUserActivity = false;
        }
        private int MaxPage()
        {
            return (int)Math.Max(Math.Ceiling(ItemsData.Count / 5.0), 1);
        }
        public void Add(Product product, int quantity = 1)
        {
            bool isAdded = false;
            foreach (var item in ItemsData)
                if (item.product == product)
                {
                    item.Quantity += quantity;
                    isAdded = true;
                }

            if (!isAdded) 
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
        // tôi muốn thêm hàm Pay() để thực hiện thanh toán
        internal async void Pay()
        {
            // tôi muốn thực hiiện thanh toán bằng cách ghi vào database 1 order mới với tổng giá và ghi chi tiết các product vào detail
            // sau đó xóa hết các sản phẩm trong giỏ hàng
            if (SessionManager.IsLoggedIn())
            {
                // tôi muốn thực hiện thanh toán bằng cách ghi vào database 1 order mới với tổng giá và ghi chi tiết các product vào detail
                // sau đó xóa hết các sản phẩm trong giỏ hàng
                DateTime date = DateTime.Now;
                Order order = new Order()
                {
                    TotalPrice = TotalValue,
                    UserID = SessionManager.CurrentUser.UserId,
                    OrderDate = date
                };
                IDaoOrder daoOrder = new PostgreDaoOrder();
                daoOrder.InsertOrder(order);

                IDaoDetail daoOrderDetail = new PostgreDaoDetail();
                List<Detail> details = new List<Detail>();

                for (int i = 0; i < ItemsData.Count;)
                    if (ItemsData[i].IsChecked)
                    {
                        Detail detail = new Detail()
                        {
                            ProductID = ItemsData[i].product.PID,
                            Quantity = ItemsData[i].Quantity,
                            Price = ItemsData[i].product.Price
                        };
                        details.Add(detail);
                        ItemsData.Remove(ItemsData[i]);
                    }
                    else i++;

                daoOrderDetail.InsertDetail(details, SessionManager.CurrentUser, date);
 
                LoadPage();
                CheckPage();
                LoadData();
                var dialog = new ContentDialog 
                { Title = "Alert", Content = "This is an alert message.", CloseButtonText = "OK" }; 
                await dialog.ShowAsync();
            }
            else
            {
                MainWindow.Instance.SetFrame(typeof(LoginPage));
            }
        }

    }
}