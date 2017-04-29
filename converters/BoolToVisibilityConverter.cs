using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Bookcase.converters
{
    class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                bool visible = (bool)value;
                return visible ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                Visibility visibility = (Visibility)value;
                return visibility == Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }
    }
}
