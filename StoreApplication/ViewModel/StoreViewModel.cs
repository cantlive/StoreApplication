using StoreApplication.Core;
using StoreApplication.Model;
using StoreApplication.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StoreApplication.ViewModel
{
    /// <summary>
    /// Represents the view model for managing the store, including displaying products and adding them to the shopping cart.
    /// </summary>
    public class StoreViewModel : ViewModelBase
    {
        private IProductLoaderService _productLoaderService;
        private ICartService _cartService;

        /// <summary>
        /// Initializes a new instance of the StoreViewModel class with the specified product loader service and cart service.
        /// </summary>
        /// <param name="productLoaderService">The product loader service used for loading products.</param>
        /// <param name="cartService">The cart service used for managing the shopping cart.</param>
        public StoreViewModel(IProductLoaderService productLoaderService, ICartService cartService)
        {           
            _productLoaderService = productLoaderService;
            _cartService = cartService;

            InitProducts();
            AddToCartCommand = new RelayCommand(AddToCart, o => true);
        }

        /// <summary>
        /// Gets or sets the collection of products available in the store.
        /// </summary>
        public ObservableCollection<Product> Products { get; set; } = new();

        /// <summary>
        /// Gets the command for adding a product to the shopping cart.
        /// </summary>
        public ICommand AddToCartCommand { get; set; }

        private void InitProducts()
        {
            var products = _productLoaderService.GetProductsOrCreate("products.json");
            _productLoaderService.LoadProductsImages(products);

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
