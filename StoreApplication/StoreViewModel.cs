using StoreApplication.LoadData;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace StoreApplication
{
    public class StoreViewModel : INotifyPropertyChanged
    {
        private readonly ProductLoader _productLoader = new();
        public ObservableCollection<Product> Products { get; set; } = new();
        public ICommand AddToCartCommand { get; set; }

        public StoreViewModel()
        {
            InitProducts();
            AddToCartCommand = new RelayCommand(AddToCart);
        }

        private void InitProducts() 
        {
            List<Product> products = _productLoader.GetProductsOrCreate("products.json");

            foreach (var product in products)
                Products.Add(product);
        }

        private void AddToCart(object obj)
        {
            if (obj is Product product)
                product.IsInCart = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
