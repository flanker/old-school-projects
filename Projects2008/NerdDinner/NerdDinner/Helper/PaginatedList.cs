using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NerdDinner.Helper
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(IQueryable<T> Source, int PageIndex, int PageSize)
        {
            this.PageIndex = PageIndex;
            this.PageSize = PageSize;
            this.TotalCount = Source.Count();
            this.TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            this.AddRange(Source.Skip(PageIndex * PageSize).Take(PageSize));
        }

        public bool HasPreviousPage
        {
            get { return PageIndex > 0; }
        }

        public bool HasNextPage
        {
            get { return PageIndex + 1 < TotalPages; }
        }

    }
}
