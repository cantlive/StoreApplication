using StoreApplication.Core;
using StoreApplication.Model;
using StoreApplication.Services;
using System.Windows.Input;

namespace StoreApplication.ViewModel
{
    /// <summary>
    /// Represents the view model for managing the shopping cart, handling interactions between the user interface and the cart service.
    /// </summary>
    public class CartViewModel : ViewModelBase
    {
        private ICartService _cartService;

        /// <summary>
        /// Initializes a new instance of the CartViewModel class with the specified cart service.
        /// </summary>
        /// <param name="cartService">The cart service used for managing the shopping cart.</param>
        public CartViewModel(ICartService cartService)
        {
            CartService = cartService;
            RemoveProductFromCartCommand = new RelayCommand(RemoveProductFromCart, o => true);

            LoadCartProducts();
        }

        /// <summary>
        /// Gets or sets the cart service used for managing the shopping cart.
        /// </summary>
        public ICartService CartService
        {
            get { return _cartService; }
            set
            {
                _cartService = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the command for removing a product from the cart.
        /// </summary>
        public ICommand RemoveProductFromCartCommand { get; set; }

        private void RemoveProductFromCart(object o) 
        {
            if (o is Product product)
                _cartService.RemoveFromCart(product);
        }

        private void LoadCartProducts()
        {
            _cartService.LoadProducts();
        }
    }
}
