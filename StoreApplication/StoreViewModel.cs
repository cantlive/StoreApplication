using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace StoreApplication
{
    public class StoreViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ProductModel> Products { get; set; }
        public ICommand AddToCartCommand { get; set; }

        public StoreViewModel()
        {
            Products = new ObservableCollection<ProductModel>()
            {
                new() {Name = "Product 1", Price = 10},
                new() {Name = "Product 2", Price = 15},
                new() {Name = "Product 3", Price = 15},
                new() {Name = "Product 4", Price = 15},
                new() {Name = "Product 5", Price = 15},
                new() {Name = "Product 6", Price = 15},
            };

            AddToCartCommand = new RelayCommand(AddToCart);
        }

        private void AddToCart(object obj)
        {
            if (obj is ProductModel product)
                product.IsInCart = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
