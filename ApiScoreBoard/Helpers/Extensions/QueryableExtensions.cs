using ApiScoreBoard.Helpers.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
namespace ApiScoreBoard.Helpers.Extensions
{
    public static class QueryableExtensions
    {
        //public static IQueryable<T> ApplyFiltering<T>(this IQueryable<T> query, IQueryObject queryObj)
        //{
        //    if (!string.IsNullOrWhiteSpace(queryObj.FilterBy))
        //        query = query.Where(queryObj.FilterBy);

        //    return query;
        //}
        //public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObj)
        //{
        //    if (string.IsNullOrWhiteSpace(queryObj.SortBy))
        //        return query;

        //    return (queryObj.IsSortAscending) ? query.OrderBy(queryObj.SortBy) : query.OrderBy(queryObj.SortBy + " descending");
        //}

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            if (queryObj.Page <= 0)
                queryObj.Page = 1;

            if (queryObj.PageSize <= 0)
                queryObj.PageSize = 10;

            return query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);
        }
    }
}