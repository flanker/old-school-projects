using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resources;

namespace flankerbase2.Helpers
{
    public static class IQueryablePaginateExtension
    {
        /// <summary>
        /// fetch part of the queryable data and build pagination data for view to render pagination links
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="page">current page number</param>
        /// <param name="pageSize">item per page</param>
        /// <param name="viewData">used for store pagination data, which for view to render pagination links</param>
        /// <returns></returns>
        public static IQueryable<T> Paginate<T>(this IQueryable<T> list, int page, int pageSize, ViewDataDictionary viewData)
        {
            viewData["_PaginationData"] = PaginationData.Build(
                new PaginationOption
                {
                    TotalCount = list.Count(),
                    Page = page,
                    PageSize = pageSize,
                    NextText = Strings.next,
                    PreviousText = Strings.previous
                });
            return list.Skip((page - 1) * pageSize).Take(pageSize);
        }

    }
}
