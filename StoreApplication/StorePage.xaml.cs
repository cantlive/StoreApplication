using System.Windows.Controls;

namespace StoreApplication
{
    public partial class StorePage : Page
    {
        public StorePage()
        {
            InitializeComponent();
            DataContext = new StoreViewModel();
        }
    }
}
