using StoreApplication.Core;
using StoreApplication.Model;

namespace StoreApplication.Services
{
    public class ProductLoaderService : IProductLoaderService
    {
        private JsonSerializer<Product> _jsonSerializer = new();

        public List<Product> GetProductsOrCreate(string fileName)
        {
            List<Product> products = GetProducts(fileName);
            if (products.Count == 0)
            {
                List<Product> sampleProducts = GetSampleProducts();
                SaveProducts(sampleProducts, fileName);
            }

            return GetProducts(fileName);
        }

        public List<Product> GetProducts(string fileName)
        {
            return _jsonSerializer.LoadData(fileName);
        }

        public void SaveProducts(List<Product> products, string fileName)
        {
            _jsonSerializer.SaveData(products, fileName);
        }

        private static List<Product> GetSampleProducts()
        {
            return
            [
                new() { Name = "product1", Price = 10, Quantity = 1 },
                new() { Name = "product2", Price = 20, Quantity = 1 },
                new() { Name = "product3", Price = 30, Quantity = 1 },
                new() { Name = "product4", Price = 40, Quantity = 1 },
                new() { Name = "product5", Price = 50, Quantity = 1 },
                new() { Name = "product6", Price = 60, Quantity = 1 },
                new() { Name = "product7", Price = 70, Quantity = 1 },
                new() { Name = "product8", Price = 80, Quantity = 1 },
                new() { Name = "product9", Price = 100, Quantity = 1 },
                new() { Name = "product10", Price = 110, Quantity = 1 },
                new() { Name = "product11", Price = 120, Quantity = 1 },
                new() { Name = "product12", Price = 130, Quantity = 1 },
                new() { Name = "product13", Price = 140, Quantity = 1 },
                new() { Name = "product14", Price = 150, Quantity = 1 },
                new() { Name = "product15", Price = 160, Quantity = 1 },
                new() { Name = "product16", Price = 170, Quantity = 1 },
                new() { Name = "product17", Price = 180, Quantity = 1 },
                new() { Name = "product18", Price = 190, Quantity = 1 },
                new() { Name = "product19", Price = 200, Quantity = 1 },
                new() { Name = "product20", Price = 210, Quantity = 1 }
            ];
        }
    }
}
