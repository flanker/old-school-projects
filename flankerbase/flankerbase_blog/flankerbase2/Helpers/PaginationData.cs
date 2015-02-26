using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flankerbase2.Helpers
{
    /// <summary>
    /// stored in ViewData and used for htmlHelper of view to display pagination links
    /// </summary>
    public class PaginationData
    {
        private static readonly int _pageSize = 5;
        private static readonly string _previousText = "« previous";
        private static readonly string _nextText = "next »";
        private static readonly string _htmlClass = "highContrast";

        public int TotalCount { get; private set; }

        public int TotalPages { get; private set; }
        public int CurrentPage { get; private set; }

        public PaginationLink PreviousLink { get; private set; }
        public PaginationLink NextLink { get; private set; }

        public static PaginationData Build(PaginationOption option)
        {
            PaginationData result = new PaginationData();
            result.TotalCount = option.TotalCount;
            result.CurrentPage = option.Page;
            int page = option.Page;
            result.TotalPages = (int)Math.Ceiling(option.TotalCount / (double)(option.PageSize ?? _pageSize));
            result.PreviousLink = new PaginationLink { Text = option.PreviousText ?? _previousText, Page = page - 1, IsLink = page != 1, HtmlClass = option.HtmlClass ?? _htmlClass };
            result.NextLink = new PaginationLink { Text = option.NextText ?? _nextText, Page = page + 1, IsLink = page != result.TotalPages, HtmlClass = option.HtmlClass ?? _htmlClass };
            return result;
        }

    }

    /// <summary>
    /// used for render a page link
    /// </summary>
    public class PaginationLink
    {
        /// <summary>
        /// text displayed 
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// which page linked to
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// is this 'a' tag or 'span' tag
        /// </summary>
        public bool IsLink { get; set; }
        /// <summary>
        /// html attribute 'class' for tag
        /// </summary>
        public string HtmlClass { get; set; }
    }

    /// <summary>
    /// option to build a PaginationData
    /// </summary>
    public class PaginationOption
    {
        /// <summary>
        /// count of total pages
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// current page number
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// items per page. null means using default size (PaginationData._pageSize)
        /// </summary>
        public int? PageSize { get; set; }
        /// <summary>
        /// text displayed for previous page link
        /// </summary>
        public string PreviousText { get; set; }
        /// <summary>
        /// text displayed for next page link
        /// </summary>
        public string NextText { get; set; }
        /// <summary>
        /// html attribute 'class' for links
        /// </summary>
        public string HtmlClass { get; set; }
    }
}
