using StoreApplication.Core;
using StoreApplication.Model;
using System.IO;
using System.Windows.Media.Imaging;
using Windows.Storage;
using Windows.UI.Xaml;

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

        public void LoadProductsImages(List<Product> products)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;

            foreach (var product in products)
            {
                if (!File.Exists(product.Image))
                {
                    product.ImageSource = new BitmapImage();
                    continue;
                }

                var file = localFolder.GetFileAsync(product.Image).GetResults();
                product.ImageSource = new BitmapImage(new Uri(Path.GetFullPath(file.Path)));
            }
        }

        private static List<Product> GetSampleProducts()
        {
            return
            [
                new() { ID = 1, Name = "product1", Price = 10, Quantity = 1, Image = "product1.jpg" },
                new() { ID = 2, Name = "product2", Price = 20, Quantity = 1, Image = "product2.jpg" },
                new() { ID = 3, Name = "product3", Price = 30, Quantity = 1 },
                new() { ID = 4, Name = "product4", Price = 40, Quantity = 1 },
                new() { ID = 5, Name = "product5", Price = 50, Quantity = 1 },
                new() { ID = 6, Name = "product6", Price = 60, Quantity = 1 },
                new() { ID = 7, Name = "product7", Price = 70, Quantity = 1 },
                new() { ID = 8, Name = "product8", Price = 80, Quantity = 1 },
                new() { ID = 9, Name = "product9", Price = 100, Quantity = 1 },
                new() { ID = 10, Name = "product10", Price = 110, Quantity = 1 },
                new() { ID = 11, Name = "product11", Price = 120, Quantity = 1 },
                new() { ID = 12, Name = "product12", Price = 130, Quantity = 1 },
                new() { ID = 13, Name = "product13", Price = 140, Quantity = 1 },
                new() { ID = 14, Name = "product14", Price = 150, Quantity = 1 },
                new() { ID = 15, Name = "product15", Price = 160, Quantity = 1 },
                new() { ID = 16, Name = "product16", Price = 170, Quantity = 1 },
                new() { ID = 17, Name = "product17", Price = 180, Quantity = 1 },
                new() { ID = 18, Name = "product18", Price = 190, Quantity = 1 },
                new() { ID = 19, Name = "product19", Price = 200, Quantity = 1 },
                new() { ID = 20, Name = "product20", Price = 210, Quantity = 1 }
            ];
        }
    }
}
