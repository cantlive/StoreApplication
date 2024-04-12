using System.Collections.ObjectModel;
using StoreApplication.Model;

namespace StoreApplication.Services
{
    public class CartService : ICartService
    {
        private readonly IProductLoaderService _productLoaderService;

        public CartService(IProductLoaderService productLoaderService)
        {
            _productLoaderService = productLoaderService;
        }

        public ObservableCollection<Product> CartProducts { get; } = new();

        public void AddToCart(Product product)
        {
            CartProducts.Add(product);
        }

        public void LoadProducts()
        {
            var products = _productLoaderService.GetProducts("cartProducts.json");

            foreach (var product in products)
                AddToCart(product);
        }

        public void SaveProducts()
        {
            _productLoaderService.SaveProducts(CartProducts.ToList(), "cartProducts.Json");
        }
    }
}
