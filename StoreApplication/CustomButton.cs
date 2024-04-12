using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StoreApplication
{
    public class CustomButton : Button
    {
        public static readonly DependencyProperty ButtonColorProperty =
            DependencyProperty.Register("ButtonColor", typeof(Brush), typeof(CustomButton), new PropertyMetadata(Brushes.Gray));

        public Brush ButtonColor
        {
            get { return (Brush)GetValue(ButtonColorProperty); }
            set { SetValue(ButtonColorProperty, value); }
        }

        public CustomButton()
        {
            DefaultStyleKey = typeof(CustomButton);
        }
    }
}
