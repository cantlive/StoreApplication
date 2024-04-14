using StoreApplication.Core;

namespace StoreApplication.Services
{
    /// <summary>
    /// Defines the contract for a service responsible for navigation within the application.
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Gets the current view model being displayed.
        /// </summary>
        ViewModelBase CurrentView { get; }

        /// <summary>
        /// Navigates to the specified view model type.
        /// </summary>
        /// <typeparam name="T">The type of view model to navigate to. Must derive from ViewModelBase.</typeparam>
        void NaviagteTo<T>() where T : ViewModelBase;
    }
}
