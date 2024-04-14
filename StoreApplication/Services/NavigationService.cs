using StoreApplication.Core;

namespace StoreApplication.Services
{
    /// <summary>
    /// Provides functionality for navigating between view models in the application.
    /// </summary>
    public class NavigationService : ObservableObject, INavigationService
    {
        private ViewModelBase _currentView;
        private readonly Func<Type, ViewModelBase> _viewModelFactory;

        /// <summary>
        /// Gets or sets the current view model being displayed.
        /// </summary>
        public ViewModelBase CurrentView 
        {
            get => _currentView;
            private set
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the NavigationService class with the specified view model factory.
        /// </summary>
        /// <param name="viewModelFactory">The factory function used to create view models.</param>
        public NavigationService(Func<Type, ViewModelBase> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        /// <summary>
        /// Navigates to the specified view model type.
        /// </summary>
        /// <typeparam name="TViewModel">The type of view model to navigate to.</typeparam>
        public void NaviagteTo<TViewModel>() where TViewModel : ViewModelBase
        {
            var viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentView = viewModel;
        }
    }
}
