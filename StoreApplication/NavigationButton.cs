using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StoreApplication
{
    public class NavigationButton : ListBoxItem
    {
        static NavigationButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationButton), new FrameworkPropertyMetadata(typeof(NavigationButton)));
        }

        public string NavigationPath
        {
            get { return (string)GetValue(NavigationPathProperty); }
            set { SetValue(NavigationPathProperty, value); }
        }

        public static readonly DependencyProperty NavigationPathProperty =
            DependencyProperty.Register("NavigationPath", typeof(string), typeof(NavigationButton), new PropertyMetadata(null));


        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(NavigationButton), new PropertyMetadata(null));
    }
}
