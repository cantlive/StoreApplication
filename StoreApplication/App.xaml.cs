using Autofac;
using StoreApplication.Core;
using StoreApplication.Services;
using StoreApplication.View;
using StoreApplication.ViewModel;
using System.Windows;

namespace StoreApplication
{
    public partial class App : Application
    {
        private IContainer _container;

        public App()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf().SingleInstance();

            builder.RegisterType<StorePage>().AsSelf();
            builder.RegisterType<StoreViewModel>().AsSelf().SingleInstance();

            builder.RegisterType<CartPage>().AsSelf();
            builder.RegisterType<CartViewModel>().AsSelf().SingleInstance();

            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<ProductLoaderService>().As<IProductLoaderService>().SingleInstance();
            builder.RegisterType<CartService>().As<ICartService>().SingleInstance();

            builder.Register<Func<Type, ViewModelBase>>(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return viewModelType => (ViewModelBase)context.Resolve(viewModelType);
            });

            _container = builder.Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _container.Resolve<MainWindow>();
            mainWindow.DataContext = _container.Resolve<MainViewModel>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            var cartService = _container.Resolve<ICartService>();
            cartService.SaveProducts();
            base.OnExit(e);
        }
    }
}