using System.Collections.ObjectModel;
using StoreApplication.Model;

namespace StoreApplication.Services
{
    /// <summary>
    /// Defines the contract for a service responsible for managing a shopping cart.
    /// </summary>
    public interface ICartService
    {
        /// <summary>
        /// Gets the collection of products in the shopping cart.
        /// </summary>
        ObservableCollection<Product> CartProducts { get; }

        /// <summary>
        /// Adds the specified product to the shopping cart.
        /// </summary>
        /// <param name="product">The product to add to the shopping cart.</param>
        void AddToCart(Product product);

        /// <summary>
        /// Loads products into the shopping cart from a data source.
        /// </summary>
        void LoadProducts();

        /// <summary>
        /// Saves the products in the shopping cart to a data source.
        /// </summary>
        void SaveProducts();

        /// <summary>
        /// Removes the specified product from the shopping cart.
        /// </summary>
        /// <param name="product">The product to remove from the shopping cart.</param>
        void RemoveFromCart(Product product);
    }
}
