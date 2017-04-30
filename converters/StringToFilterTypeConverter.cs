using Bookcase.model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Bookcase.converters
{
    class StringToFilterTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                FilterType filter = (FilterType)value;

                switch (filter)
                {
                    case FilterType.STARTED:
                        return Properties.Resources.FilterTypeStarted;

                    case FilterType.READ:
                        return Properties.Resources.FilterTypeRead;

                    case FilterType.NOT_READ:
                        return Properties.Resources.FilterTypeNotRead;

                    case FilterType.NOT_OWNED:
                        return Properties.Resources.FilterTypeNotOwned;

                    case FilterType.ALL:
                    default:
                        return Properties.Resources.FilterTypeAll;
                }
            }
            else
            {
                return Properties.Resources.FilterTypeAll;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                String type = (String)value;

                var filters = new Dictionary<String, FilterType>
                {
                    { Properties.Resources.FilterTypeRead, FilterType.READ },
                    { Properties.Resources.FilterTypeStarted, FilterType.STARTED },
                    { Properties.Resources.FilterTypeNotRead, FilterType.NOT_READ },
                    { Properties.Resources.FilterTypeNotOwned, FilterType.NOT_OWNED },
                    { Properties.Resources.FilterTypeAll, FilterType.ALL }
                };

                FilterType result;

                if (filters.TryGetValue(type, out result))
                    return result;
                else
                    return FilterType.ALL;
            }
            else
            {
                return FilterType.ALL;
            }
        }
    }
}
