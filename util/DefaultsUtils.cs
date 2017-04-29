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
            return new String[] { "Tytuł", "Autor" };
        }

        public static Boolean[] GetDefaultFilters()
        {
            Boolean[] array = new Boolean[5];
            array[0] = true;
            return array;
        }
    }
}
