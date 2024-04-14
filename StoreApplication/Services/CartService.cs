using System.Collections.ObjectModel;
using StoreApplication.Core;
using StoreApplication.Model;

namespace StoreApplication.Services
{
    /// <summary>
    /// Provides functionality for managing a shopping cart, including adding, removing, and persisting products, as well as calculating total price and product count.
    /// </summary>
    public class CartService : ObservableObject, ICartService
    {
        private readonly IProductLoaderService _productLoaderService;
        private int _totalProductsCount;
        private decimal _totalPrice;

        /// <summary>
        /// Initializes a new instance of the CartService class with the specified product loader service.
        /// </summary>
        /// <param name="productLoaderService">The service used to load and save products.</param>
        public CartService(IProductLoaderService productLoaderService)
        {
            _productLoaderService = productLoaderService;
        }

        /// <summary>
        /// Gets the collection of products in the shopping cart.
        /// </summary>
        public ObservableCollection<Product> CartProducts { get; } = new();

        /// <summary>
        /// Gets or sets the total number of products in the shopping cart.
        /// </summary>
        public int TotalProductsCount
        {
            get { return _totalProductsCount; }
            set
            {
                _totalProductsCount = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the total price of all products in the shopping cart.
        /// </summary>
        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                _totalPrice = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Adds the specified product to the shopping cart.
        /// </summary>
        /// <param name="product">The product to add to the shopping cart.</param>
        public void AddToCart(Product product)
        {
            if (CartProducts.Contains(product))
                product.Quantity = product.Quantity + 1;
            else
                CartProducts.Add(product);

            CalculateTotal();
        }

        /// <summary>
        /// Loads products into the shopping cart from a data source.
        /// </summary>
        public void LoadProducts()
        {
            var products = _productLoaderService.GetProducts("cartProducts.json");
            _productLoaderService.LoadProductsImages(products);

            foreach (var product in products)
                AddToCart(product);

            CalculateTotal();
        }

        /// <summary>
        /// Saves the products in the shopping cart to a data source.
        /// </summary>
        public void SaveProducts()
        {
            _productLoaderService.SaveProducts(CartProducts.ToList(), "cartProducts.Json");
        }

        /// <summary>
        /// Removes the specified product from the shopping cart.
        /// </summary>
        /// <param name="product">The product to remove from the shopping cart.</param>
        public void RemoveFromCart(Product product)
        {
            CartProducts.Remove(product);
            CalculateTotal();
        }

        /// <summary>
        /// Calculates the total number of products and total price in the shopping cart.
        /// </summary>
        private void CalculateTotal()
        {
            TotalProductsCount = CartProducts.Sum(x => x.Quantity);
            TotalPrice = CartProducts.Sum(x => x.Quantity * x.Price);
        }
    }
}
