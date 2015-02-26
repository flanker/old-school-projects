using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyTogether.Helper
{
    public static class HtmlHelperExtensions
    {
        public static string ImageEncode(this HtmlHelper htmlHelper, string src, string alt)
        {
            return htmlHelper.ImageEncode(src, alt, null);
        }

        public static string ImageEncode(this HtmlHelper htmlHelper, string src, string alt, IDictionary<string, object> htmlAttributes)
        {
            TagBuilder tagBuilder = new TagBuilder("img");
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("src", htmlHelper.Encode(src));
            tagBuilder.MergeAttribute("alt", htmlHelper.Encode(alt));
            return tagBuilder.ToString(TagRenderMode.SelfClosing);
        }
    }
}
