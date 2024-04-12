using StoreApplication.Core;
using StoreApplication.Services;

namespace StoreApplication.ViewModel
{
    internal class CartViewModel : ViewModelBase
    {
        private ICartService _cartService;
        private int _totalProductsCount;
        private decimal _totalPrice;

        public CartViewModel(ICartService cartService)
        {
            CartService = cartService;

            LoadCartProducts();
            CalculateTotal();
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

        private void LoadCartProducts()
        {
            _cartService.LoadProducts();
        }

        private void CalculateTotal()
        {
            TotalProductsCount = _cartService.CartProducts.Count;
            TotalPrice = _cartService.CartProducts.Sum(x => x.Price);
        }
    }
}
