using StoreApplication.Core;
using StoreApplication.Services;
using System.IO;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace StoreApplication.ViewModel
{
    /// <summary>
    /// Represents the main view model for managing navigation between different pages in the application.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class with the specified navigation service.
        /// </summary>
        /// <param name="navigationService">The navigation service used for navigating between pages.</param>
        public MainViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            NavigateToStorePageCommand = new RelayCommand(o => Navigation.NaviagteTo<StoreViewModel>(), o => true);
            NavigateToCartPageCommand = new RelayCommand(o => Navigation.NaviagteTo<CartViewModel>(), o => true);

            NavigateToStorePageCommand.Execute(null);
        }

        /// <summary>
        /// Gets the icon representing the shop.
        /// </summary>
        public ImageSource ShopIcon => new BitmapImage(new Uri(Path.GetFullPath("../../../Images/shop.png")));

        /// <summary>
        /// Gets the icon representing the shopping cart.
        /// </summary>
        public ImageSource CartIcon => new BitmapImage(new Uri(Path.GetFullPath("../../../Images/shoppingCart.png")));

        /// <summary>
        /// Gets or sets the navigation service used for navigating between pages.
        /// </summary>
        public INavigationService Navigation
        {
            get { return _navigationService; }
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the command for navigating to the store page.
        /// </summary>
        public ICommand NavigateToStorePageCommand { get; set; }

        /// <summary>
        /// Gets the command for navigating to the cart page.
        /// </summary>
        public ICommand NavigateToCartPageCommand { get; set; }
    }
}
