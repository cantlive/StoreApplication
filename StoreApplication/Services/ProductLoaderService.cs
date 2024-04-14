using StoreApplication.Core;
using StoreApplication.Model;
using System.IO;
using System.Windows.Media.Imaging;
using Windows.Storage;

namespace StoreApplication.Services
{
    /// <summary>
    /// Provides functionality for loading, saving, and managing product data.
    /// </summary>
    public class ProductLoaderService : IProductLoaderService
    {
        private JsonSerializer<Product> _jsonSerializer = new();

        /// <summary>
        /// Gets the list of products from the specified file, or creates a new list if the file does not exist.
        /// </summary>
        /// <param name="fileName">The name of the file containing product data.</param>
        /// <returns>The list of products loaded from the file or a new list if the file does not exist.</returns>
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

        /// <summary>
        /// Gets the list of products from the specified file.
        /// </summary>
        /// <param name="fileName">The name of the file containing product data.</param>
        /// <returns>The list of products loaded from the file.</returns>
        public List<Product> GetProducts(string fileName)
        {
            return _jsonSerializer.LoadData(fileName);
        }

        /// <summary>
        /// Saves the list of products to the specified file.
        /// </summary>
        /// <param name="products">The list of products to save.</param>
        /// <param name="fileName">The name of the file to save the product data to.</param>
        public void SaveProducts(List<Product> products, string fileName)
        {
            _jsonSerializer.SaveData(products, fileName);
        }

        /// <summary>
        /// Loads images for the specified list of products.
        /// </summary>
        /// <param name="products">The list of products for which to load images.</param>
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
