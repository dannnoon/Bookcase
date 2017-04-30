using Bookcase.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.util
{
    class DefaultsUtils
    {
        public static String[] GetDefaultSorters()
        {
            return new String[] {
                Properties.Resources.TitleText,
                Properties.Resources.AuthorText,
                Properties.Resources.GenreText
            };
        }

        public static Boolean[] GetDefaultFilters()
        {
            Boolean[] array = new Boolean[5];
            array[0] = true;
            return array;
        }

        public static String[] GetBookFilters()
        {
            return new String[] { "Przeczytane", "Zaczęte", "Nieprzeczytane", "Nieposiadane" };
        }

        public static FilterType GetFilterTypeFromString(String type)
        {
            switch (type)
            {
                case "Przeczytane":
                    return FilterType.READ;

                case "Zaczęte":
                    return FilterType.STARTED;

                case "Nieprzeczytane":
                    return FilterType.NOT_READ;

                case "Nieposiadane":
                default:
                    return FilterType.NOT_OWNED;
            }
        }
    }
}
