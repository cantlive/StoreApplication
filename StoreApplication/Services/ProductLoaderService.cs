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
                new() { Name = "product1", Price = 10 },
                new() { Name = "product2", Price = 20 },
                new() { Name = "product3", Price = 30 },
                new() { Name = "product4", Price = 40 },
                new() { Name = "product5", Price = 50 },
                new() { Name = "product6", Price = 60 },
                new() { Name = "product7", Price = 70 },
                new() { Name = "product8", Price = 80 },
                new() { Name = "product9", Price = 100 },
                new() { Name = "product10", Price = 110 },
                new() { Name = "product11", Price = 120 },
                new() { Name = "product12", Price = 130 },
                new() { Name = "product13", Price = 140 },
                new() { Name = "product14", Price = 150 },
                new() { Name = "product15", Price = 160 },
                new() { Name = "product16", Price = 170 },
                new() { Name = "product17", Price = 180 },
                new() { Name = "product18", Price = 190 },
                new() { Name = "product19", Price = 200 },
                new() { Name = "product20", Price = 210 }
            ];
        }
    }
}
