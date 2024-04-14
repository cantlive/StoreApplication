using StoreApplication.Core;
using StoreApplication.Model;
using System.IO;
using System.Windows.Media.Imaging;
using Windows.Storage;

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
                LoadImagesFromSample(sampleProducts);
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

        private List<Product> GetSampleProducts() 
        {
            return _jsonSerializer.LoadData(Path.GetFullPath("../../../Sample/products.json"));
        }

        private void LoadImagesFromSample(List<Product> products) 
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            foreach (var product in products)
            {
                if (string.IsNullOrEmpty(product.Image))
                    continue;

                var imagePath = Path.GetFullPath($"../../../Sample/{product.Image}");
                using var imageWriter = File.Open(imagePath, FileMode.Open);
                StorageFile photoFile = localFolder.CreateFileAsync(product.Image, CreationCollisionOption.ReplaceExisting).GetResults();
                using var photoOutputStream = photoFile.OpenStreamForWriteAsync().Result;
                imageWriter.CopyTo(photoOutputStream);
            }
        }
    }
}
