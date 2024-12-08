using Microsoft.UI.Xaml;
using SellingTree.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using SellingTree.IDao;
using SellingTree.View;
namespace SellingTree

{
    class ShopListViewModel : INotifyPropertyChanged
    {
        public static ShopListViewModel instance = new ShopListViewModel();
        private FullObservableCollection<PageChanger> pageChangerButton = PageChanger.getPageChanger(1, 1);

        public FullObservableCollection<PageChanger> PageChangerButton
        {
            get => pageChangerButton;
            set
            {
                pageChangerButton = value;
                OnPropertyChanged(nameof(PageChangerButton));
            }

        }
        private List<MyShoppingItem> ItemsData { get; set; }

        public FullObservableCollection<MyShoppingItem> items;
        public FullObservableCollection<MyShoppingItem> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        private int MaxValue;
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

        public int _currentPage;
        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
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

        private int _totalValue = 0;
        public int TotalValue
        {
            get => _totalValue; set
            {
                _totalValue = value; OnPropertyChanged(nameof(TotalValue));
            }
        }

        public ShopListViewModel()
        {
            Items = new FullObservableCollection<MyShoppingItem>();
            ItemsData = new List<MyShoppingItem>();
            SelectedCount = Count = 0;
            CurrentPage = 1;
            MaxValue = 0;
        }

        private void LoadPosition()
        {
            for (int i = 0; i < ItemsData.Count; i++)
                ItemsData[i].Position = i;
        }

        public void DeleteItem(String Tag)
        {
            int index = int.Parse(Tag);
            if (ItemsData[index].IsChecked)
            {
                SelectedCount--;
                TotalValue -= ItemsData[index].Cost;
            }

            ItemsData.RemoveAt(index);
            Count--;

            LoadPosition();

            if (CurrentPage >= MaxPage())
            {
                CurrentPage = MaxPage();
                LoadPage();
            }

            CheckPage();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void LoadData()
        {
            if (IsUserActivity) return;
            Count = ItemsData.Count;
            IsUserActivity = true;
            SelectedCount = 0;
            TotalValue = 0;
            IsSelected = true;

            foreach (var item in ItemsData)
                if (item.IsChecked == true)
                {
                    SelectedCount++;
                    TotalValue += item.Cost;
                }
                else IsSelected = false;

            IsUserActivity = false;

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

            MaxValue += ItemsData.Last().Cost;
            TotalValue += ItemsData.Last().Cost;
            SelectedCount++; Count++;

            if (CurrentPage == MaxPage())
                LoadPage();
            if (Count % 5 == 1)
                CheckPage();
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
        internal void Pay()
        {
            // tôi muốn thực hiiện thanh toán bằng cách ghi vào database 1 order mới với tổng giá và ghi chi tiết các product vào detail
            // sau đó xóa hết các sản phẩm trong giỏ hàng
            if (SessionManager.IsLoggedIn())
            {
                // tôi muốn thực hiện thanh toán bằng cách ghi vào database 1 order mới với tổng giá và ghi chi tiết các product vào detail
                // sau đó xóa hết các sản phẩm trong giỏ hàng
                Order order = new Order()
                {
                    TotalPrice = TotalValue,
                    UserID = SessionManager.CurrentUser.UserId,
                    OrderDate = DateTime.Now
                };
                IDaoOrder daoOrder = new PostgreDaoOrder();
                daoOrder.InsertOrder(order);
                IDaoDetail daoOrderDetail = new PostgreDaoDetail();
                //foreach (var item in ItemsData)
                //{
                //    Detail detail = new Detail()
                //    {
                //        OrderID = order.OrderID,
                //        ProductID = item.product.ProductID,
                //        Quantity = item.Quantity,
                //        Price = item.product.Price
                //    };
                //    daoOrderDetail.InsertDetail(detail);
                //}
                ItemsData.Clear();
                LoadPage();
                CheckPage();
                LoadData();


            }
            else
            {
                MainWindow.Instance.SetFrame(typeof(LoginPage));
            }
        }
    }
}