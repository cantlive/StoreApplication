using StoreApplication.Core;
using StoreApplication.Services;
using System.IO;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace StoreApplication.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            NavigateToStorePageCommand = new RelayCommand(o => Navigation.NaviagteTo<StoreViewModel>(), o => true);
            NavigateToCartPageCommand = new RelayCommand(o => Navigation.NaviagteTo<CartViewModel>(), o => true);

            NavigateToStorePageCommand.Execute(null);
        }

        public ImageSource ShopIcon => new BitmapImage(new Uri(Path.GetFullPath("../../../Images/shop.png")));
        public ImageSource CartIcon => new BitmapImage(new Uri(Path.GetFullPath("../../../Images/shoppingCart.png")));

        public INavigationService Navigation
        {
            get { return _navigationService; }
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateToStorePageCommand { get; set; }
        public ICommand NavigateToCartPageCommand { get; set; }
    }
}
