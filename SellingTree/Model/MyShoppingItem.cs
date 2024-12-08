using System.ComponentModel;
using System.Windows.Input;

namespace SellingTree.Model
{
    internal partial class MyShoppingItem : INotifyPropertyChanged
    {
        private bool _isChecked;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }
        }


        public Product product { get; set; }
        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                Cost = _quantity * product.Price;
                OnPropertyChanged(nameof(Quantity));
            }
        }
        private int _position;
        public int Position
        {
            get => _position;
            set
            {
                _position = value;
                OnPropertyChanged(nameof(Position));
            }
        }
        private int _cost;
        public int Cost
        {
            get => _cost;
            set
            {
                _cost = value;
                OnPropertyChanged(nameof(Cost));
                ShopListViewModel.instance.LoadData();
            }
        }
        public MyShoppingItem(Product _product, int _quantity = 1)
        {
            product = _product;
            Quantity = _quantity;
            Cost = product.Price * Quantity;
            IsChecked = true;
        }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
