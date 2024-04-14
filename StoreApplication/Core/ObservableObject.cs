using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StoreApplication.Core
{
    /// <summary>
    /// Provides a base implementation of the INotifyPropertyChanged interface for classes that require property change notifications.
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event to indicate a property value has changed.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed. This value is optional and can be automatically determined by the compiler.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
