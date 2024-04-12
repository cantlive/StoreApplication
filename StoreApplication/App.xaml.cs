using Microsoft.Extensions.DependencyInjection;
using StoreApplication.Core;
using StoreApplication.Services;
using StoreApplication.View;
using StoreApplication.ViewModel;
using System.Windows;

namespace StoreApplication
{
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();

            services.AddSingleton(provider => new MainWindow() 
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
            services.AddSingleton<MainViewModel>();

            services.AddSingleton(provider => new StorePage()
            {
                DataContext = provider.GetRequiredService<StoreViewModel>()
            });
            services.AddSingleton<StoreViewModel>();

            services.AddSingleton(provider => new CartPage()
            {
                DataContext = provider.GetRequiredService<CartViewModel>()
            });
            services.AddSingleton<CartViewModel>();

            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IProductLoaderService, ProductLoaderService>();
            services.AddSingleton<ICartService, CartService>();
            services.AddSingleton<Func<Type, ViewModelBase>>
                (provider => viewModelType => (ViewModelBase)provider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
