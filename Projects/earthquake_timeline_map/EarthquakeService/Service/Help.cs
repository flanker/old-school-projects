using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EarthquakeService
{
    class Help
    {
        public static string ConvertDateTime(DateTime DateTime)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append(Enum.GetName(typeof(Month), DateTime.Month)).Append(" ");

            sb.Append(DateTime.Day.ToString()).Append(" ");

            sb.Append(DateTime.Year.ToString()).Append(" ");

            sb.Append(DateTime.ToLongTimeString()).Append(" ");

            sb.Append("GMT+0000");

            return sb.ToString();
        }

       
    }

    enum Month
    {
        Jan = 1,
        Feb,
        Mar,
        Apr,
        May,
        Jun,
        Jul,
        Aug,
        Spt,
        Oct,
        Nov,
        Dec
    }
}
