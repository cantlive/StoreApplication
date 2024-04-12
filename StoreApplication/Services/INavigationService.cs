using StoreApplication.Core;

namespace StoreApplication.Services
{
    public interface INavigationService
    {
        ViewModelBase CurrentView { get; }
        void NaviagteTo<T>() where T : ViewModelBase;
    }
}
