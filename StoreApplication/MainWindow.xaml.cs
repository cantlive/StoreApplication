using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace StoreApplication
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            navigationButtonStore.IsSelected = true;
            navigationButtonStore.Icon = new BitmapImage(new Uri(Path.GetFullPath("../../../Images/shop.png")));
            navigationButtonCart.Icon = new BitmapImage(new Uri(Path.GetFullPath("../../../Images/shoppingCart.png")));
        }

        private void Sidebar_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selected = sidebar.SelectedItem as NavigationButton;
            navigationFrame.Navigate(new Uri(selected?.NavigationPath, UriKind.Relative));
        }
    }
}