using System.ComponentModel;
using System.Windows.Input;

namespace SellingTree.Model
{
    public partial class MyShoppingItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isChecked;
        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
                ShopListViewModel.instance.LoadData();
            }
        }
        public Product product { get; set; }

        public int _quantity;
        public int Quantity
        {
            get => _quantity; set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
                ShopListViewModel.instance.LoadData();
            }
        }
        public int Position { get; set; }
        public int Cost => Quantity * product.Price;
        public MyShoppingItem(Product _product, int _quantity = 1)
        {
            product = _product;
            Quantity = _quantity;
            IsChecked = true;
        }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
