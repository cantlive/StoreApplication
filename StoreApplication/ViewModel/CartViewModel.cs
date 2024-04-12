using StoreApplication.Core;
using StoreApplication.Model;
using StoreApplication.Services;
using System.Windows.Input;

namespace StoreApplication.ViewModel
{
    internal class CartViewModel : ViewModelBase
    {
        private ICartService _cartService;       

        public CartViewModel(ICartService cartService)
        {
            CartService = cartService;
            RemoveProductFromCartCommand = new RelayCommand(RemoveProductFromCart, o => true);

            LoadCartProducts();
        }

        public ICartService CartService
        {
            get { return _cartService; }
            set
            {
                _cartService = value;
                OnPropertyChanged();
            }
        }

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
