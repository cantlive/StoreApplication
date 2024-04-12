using StoreApplication.Model;

namespace StoreApplication.Services
{
    public interface IProductLoaderService
    {
        List<Product> GetProductsOrCreate(string fileName);
        List<Product> GetProducts(string fileName);
        void SaveProducts(List<Product> products, string fileName);
    }
}
