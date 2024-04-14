using StoreApplication.Model;

namespace StoreApplication.Services
{
    /// <summary>
    /// Defines the contract for a service responsible for loading, saving, and managing product data.
    /// </summary>
    public interface IProductLoaderService
    {
        /// <summary>
        /// Gets the list of products from the specified file, or creates a new list if the file does not exist.
        /// </summary>
        /// <param name="fileName">The name of the file containing product data.</param>
        /// <returns>The list of products loaded from the file or a new list if the file does not exist.</returns>
        List<Product> GetProductsOrCreate(string fileName);

        /// <summary>
        /// Gets the list of products from the specified file.
        /// </summary>
        /// <param name="fileName">The name of the file containing product data.</param>
        /// <returns>The list of products loaded from the file.</returns>
        List<Product> GetProducts(string fileName);

        /// <summary>
        /// Saves the list of products to the specified file.
        /// </summary>
        /// <param name="products">The list of products to save.</param>
        /// <param name="fileName">The name of the file to save the product data to.</param>
        void SaveProducts(List<Product> products, string fileName);

        /// <summary>
        /// Loads images for the specified list of products.
        /// </summary>
        /// <param name="products">The list of products for which to load images.</param>
        void LoadProductsImages(List<Product> products);
    }
}
