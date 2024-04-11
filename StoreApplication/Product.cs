using System.ComponentModel;

namespace StoreApplication
{
    public class Product : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private decimal _price;
        private bool _isInCart;

        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public bool IsInCart
        {
            get { return _isInCart; }
            set
            {
                _isInCart = value;
                OnPropertyChanged(nameof(IsInCart));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
