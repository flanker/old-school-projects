using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xiaonei.Utilities
{
    /// <summary>
    /// 集合扩展类，请用扩展方法调用
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// 将一个字符串字典里的键和值转换为URI查询字符串，该方法目前不对键进行排序，也不对值进行Url编码
        /// </summary>
        /// <param name="dict">实现了IDictionary&lt;string, string&gt;的字典实例</param>
        /// <returns>查询字符串</returns>
        public static string ToQueryString(this IDictionary<string, string> dict)
        {
            if (dict.Count == 0) return string.Empty;

            var buffer = new StringBuilder();
            int count = 0;
            bool end = false;

            foreach (var key in dict.Keys)
            {
                if (count == dict.Count - 1) end = true;

                if (end)
                    buffer.AppendFormat("{0}={1}", key, dict[key]);
                else
                    buffer.AppendFormat("{0}={1}&", key, dict[key]);

                count++;
            }

            return buffer.ToString();
        }

        /// <summary>
        /// 将集合里的元素以逗号分隔的字符串形式返回，该方法总是返回集合类型元素T的ToString()的值
        /// </summary>
        /// <typeparam name="T">集合中元素的类型，必要时请重载T.ToString()方法返回需要的值</typeparam>
        /// <param name="tArray"></param>
        /// <returns>以逗号分隔的字符串</returns>
        public static string ToCommaString<T>(this IEnumerable<T> tArray)
        {
            if (tArray.Count() == 0) return string.Empty;

            var buffer = new StringBuilder();
            int count = 0;
            bool end = false;

            foreach (var t in tArray)
            {
                if (count == tArray.Count() - 1) end = true;

                if (end)
                    buffer.AppendFormat("{0}", t.ToString());
                else
                    buffer.AppendFormat("{0},", t.ToString());

                count++;
            }

            return buffer.ToString();
        }
    }
}