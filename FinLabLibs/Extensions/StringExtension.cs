using System;
using System.Collections.Generic;
using System.Text;

namespace FinLabLibs
{
    public static class StringExtension
    {
        public static bool IsNullOrEmpty(this String str)
        {
            return string.IsNullOrEmpty(str);
        }
    }
}
