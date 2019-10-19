using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenHouse.Core.GraphQl.requestHelpers;
using Microsoft.EntityFrameworkCore;

namespace GreenHouse.Context.extensions
{
    public static class DataContextExtensions
    {
        public static async Task<Tuple<int, List<TSource>>> WithPaginationAsync<TSource>(
            this IQueryable<TSource> source, PagedRequest paging)
        {
            if (paging == null) throw new ArgumentNullException();
            return new Tuple<int, List<TSource>>(
                await source.CountAsync(),
                await source.Skip(paging.Offset).Take(paging.Take).AsQueryable()
                    .ToListAsync());
        }

        public static IQueryable<TSource> WithOrdering<TSource>(this IQueryable<TSource> source,
            OrderedRequest ordering,
            OrderedRequest defaultOrdering)
        {
            if (ordering == null || string.IsNullOrEmpty(ordering.OrderBy))
                ordering = defaultOrdering;

            return source.OrderBy(ordering.OrderBy, ordering.OrderDirection);
        }
    }
}