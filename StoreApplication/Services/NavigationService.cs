using StoreApplication.Core;

namespace StoreApplication.Services
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private ViewModelBase _currentView;
        private readonly Func<Type, ViewModelBase> _viewModelFactory;

        public ViewModelBase CurrentView 
        {
            get => _currentView;
            private set
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public NavigationService(Func<Type, ViewModelBase> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void NaviagteTo<TViewModel>() where TViewModel : ViewModelBase
        {
            var viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentView = viewModel;
        }
    }
}
