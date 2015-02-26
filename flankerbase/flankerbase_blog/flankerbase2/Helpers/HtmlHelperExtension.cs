using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Web.Mvc.Html;

namespace flankerbase2.Helpers
{
    public static class HtmlHelperExtension
    {
        public static string Javascript(this HtmlHelper helper, string fileName)
        {
            string filePath = String.Format("~/content/javascripts/{0}.js", fileName);
            string contentPath = PathHelpers.GenerateClientUrl(helper.ViewContext.HttpContext, filePath);

            TagBuilder tagBuilder = new TagBuilder("script");
            tagBuilder.MergeAttribute("src", contentPath);
            tagBuilder.MergeAttribute("type", "text/javascript");
            return tagBuilder.ToString(TagRenderMode.Normal) + Environment.NewLine;
        }

        public static string Javascript(this HtmlHelper helper, params string[] fileNames)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string fileName in fileNames)
            {
                sb.Append(helper.Javascript(fileName));
            }
            return sb.ToString();
        }

        public static string Stylesheet(this HtmlHelper helper, string fileName)
        {
            string filePath = String.Format("~/content/stylesheets/{0}.css", fileName);
            string contentPath = PathHelpers.GenerateClientUrl(helper.ViewContext.HttpContext, filePath);

            TagBuilder tagBuilder = new TagBuilder("link");
            tagBuilder.MergeAttribute("href", contentPath);
            tagBuilder.MergeAttribute("rel", "Stylesheet");
            tagBuilder.MergeAttribute("type", "text/css");
            return tagBuilder.ToString(TagRenderMode.SelfClosing) + Environment.NewLine;
        }

        public static string Stylesheet(this HtmlHelper helper, params string[] fileNames)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string fileName in fileNames)
            {
                sb.Append(helper.Stylesheet(fileName));
            }
            return sb.ToString();
        }

        public static string Image(this HtmlHelper helper, string fileName, string alt)
        {
            return helper.Image(fileName, alt, null);
        }

        public static string Image(this HtmlHelper helper, string fileName, string alt, IDictionary<string, object> htmlAttributes)
        {
            string filePath = String.Format("~/content/images/{0}", fileName);
            string contentPath = PathHelpers.GenerateClientUrl(helper.ViewContext.HttpContext, filePath);

            TagBuilder tagBuilder = new TagBuilder("img");
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("src", contentPath);
            tagBuilder.MergeAttribute("alt", alt);
            return tagBuilder.ToString(TagRenderMode.SelfClosing);
        }

        /// <summary>
        /// render pagination links (assume that there is PaginationData stored in ViewData)
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static string Paginate(this HtmlHelper helper)
        {
            string actionName = helper.ViewContext.RouteData.Values["action"].ToString();

            PaginationData paginationData = helper.ViewData["_PaginationData"] as PaginationData;
            if (paginationData == null)
            {
                return "no pagination data";
            }
            StringBuilder output = new StringBuilder();

            output.Append(helper.NavigationTag(paginationData.PreviousLink, actionName));

            output.Append(" ");

            output.Append(helper.NavigationTag(paginationData.NextLink, actionName));

            return output.ToString();
        }

        private static string NavigationTag(this HtmlHelper helper, PaginationLink link, string actionName)
        {
            if (link.IsLink)
            {
                MvcHtmlString htmlString = helper.ActionLink(link.Text, actionName, new { page = link.Page }, new { @class = link.HtmlClass });
                return htmlString.ToHtmlString();
            }
            else
            {
                return NavigationSpan(link);
            }
        }

        private static string NavigationSpan(PaginationLink link)
        {
            TagBuilder tagBuilder = new TagBuilder("span");
            tagBuilder.MergeAttribute("class", link.HtmlClass + " highContrastDisabled");
            tagBuilder.SetInnerText(link.Text);
            return tagBuilder.ToString(TagRenderMode.Normal);
        }

    }
}
