using StoreApplication.Core;
using StoreApplication.Model;
using StoreApplication.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StoreApplication.ViewModel
{
    public class StoreViewModel : ViewModelBase
    {
        private IProductLoaderService _productLoaderService;
        private ICartService _cartService;

        public StoreViewModel(IProductLoaderService productLoaderService, ICartService cartService)
        {
            _cartService = cartService;
            _productLoaderService = productLoaderService;

            InitProducts();
            AddToCartCommand = new RelayCommand(AddToCart, o => true);
        }

        public ObservableCollection<Product> Products { get; set; } = new();
        public ICommand AddToCartCommand { get; set; }

        private void InitProducts()
        {
            var products = _productLoaderService.GetProductsOrCreate("products.json");

            foreach (var product in products)
                Products.Add(product);
        }

        private void AddToCart(object obj)
        {
            if (obj is Product product)
                _cartService.AddToCart(product);
        }
    }
}
