using System;
using System.Linq;
using System.Linq.Expressions;

namespace NeredeKal.SharedKernel.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> query, bool condition, Expression<Func<TSource, bool>> predicate)
        {
            if (condition)
                return query.Where(predicate);

            return query;
        }

        public static IQueryable<TSource> PageBy<TSource>(this IQueryable<TSource> query, int skipCount = 0, int maxResultCount = int.MaxValue)
        {
            return query.Skip(skipCount).Take(maxResultCount);
        }
    }
}
