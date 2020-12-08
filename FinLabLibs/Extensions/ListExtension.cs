using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinLabLibs
{
    public static class ListExtension
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            if (list == null) return true;
            if (list.Any())
                return false;
            else
                return true;
        }

        

        public static List<T> SingleToList<T>(this T item)
        {
            return new List<T>() { item };
        }
    }
}
