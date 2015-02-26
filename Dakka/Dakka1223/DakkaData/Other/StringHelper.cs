using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DakkaData
{
    public class StringHelper
    {
        public static bool IsUseful(string test)
        {
            if (string.IsNullOrEmpty(test))
            {
                return false;
            }
            if (test == "null" || test == "undefined")
            {
                return false;
            }
            return true;
        }
    }
}
