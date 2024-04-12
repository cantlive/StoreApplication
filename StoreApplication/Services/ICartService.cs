using System.Collections.ObjectModel;
using StoreApplication.Model;

namespace StoreApplication.Services
{
    public interface ICartService
    {
        ObservableCollection<Product> CartProducts { get; }
        void AddToCart(Product product);
        void LoadProducts();
        void SaveProducts();
    }
}
