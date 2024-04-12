using System.Collections.ObjectModel;
using StoreApplication.Core;
using StoreApplication.Model;

namespace StoreApplication.Services
{
    public class CartService : ObservableObject, ICartService
    {
        private readonly IProductLoaderService _productLoaderService;
        private int _totalProductsCount;
        private decimal _totalPrice;

        public CartService(IProductLoaderService productLoaderService)
        {
            _productLoaderService = productLoaderService;
        }

        public ObservableCollection<Product> CartProducts { get; } = new();

        public int TotalProductsCount
        {
            get { return _totalProductsCount; }
            set
            {
                _totalProductsCount = value;
                OnPropertyChanged();
            }
        }

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                _totalPrice = value;
                OnPropertyChanged();
            }
        }

        public void AddToCart(Product product)
        {
            CartProducts.Add(product);
            CalculateTotal();
        }

        public void LoadProducts()
        {
            var products = _productLoaderService.GetProducts("cartProducts.json");

            foreach (var product in products)
                AddToCart(product);

            CalculateTotal();
        }

        public void SaveProducts()
        {
            _productLoaderService.SaveProducts(CartProducts.ToList(), "cartProducts.Json");
        }

        public void RemoveFromCart(Product product)
        {
            CartProducts.Remove(product);
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            TotalProductsCount = CartProducts.Count;
            TotalPrice = CartProducts.Sum(x => x.Price);
        }
    }
}
