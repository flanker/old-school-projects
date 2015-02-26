using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;

namespace ProjectMvc.Test
{
    public static class XpQueryExtentions
    {
        public static void ForEach<T>(this XPQuery<T> source, Action<T> action)
        {
            foreach (T item in source)
            {
                action(item);
            }
        }
    }
}
