using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureExample.Application.Persistence.Extensions
{
    public static class IQueryableExtensions
    {
        public static Task<List<TEntity>> ToListAsync<TEntity>(this IQueryable<TEntity> queryable,
            CancellationToken cancellationToken = default)
            => QueryableAsyncFactory.QueryableAsync.ToListAsync(queryable, cancellationToken);

        public static Task<TEntity[]> ToArrayAsync<TEntity>(this IQueryable<TEntity> queryable, CancellationToken cancellationToken = default)
            => QueryableAsyncFactory.QueryableAsync.ToArrayAsync(queryable, cancellationToken);

        public static Task LoadAsync<TEntity>(this IQueryable<TEntity> queryable, CancellationToken cancellationToken = default) 
            => QueryableAsyncFactory.QueryableAsync.LoadAsync(queryable, cancellationToken);
        
        public static Task<Dictionary<TKey, TEntity>> ToDictionaryAsync<TKey, TEntity>(this IQueryable<TEntity> queryable, Func<TEntity, TKey> keySelector, CancellationToken cancellationToken = default)
            => QueryableAsyncFactory.QueryableAsync.ToDictionaryAsync(queryable, keySelector, cancellationToken);
        
        public static Task<Dictionary<TKey, TEntity>> ToDictionaryAsync<TKey, TEntity>(this IQueryable<TEntity> queryable, Func<TEntity, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
            => QueryableAsyncFactory.QueryableAsync.ToDictionaryAsync(queryable, keySelector, comparer, cancellationToken);
        
        public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement, TEntity>(this IQueryable<TEntity> queryable, Func<TEntity, TKey> keySelector, Func<TEntity, TElement> elementSelector, CancellationToken cancellationToken = default)
            => QueryableAsyncFactory.QueryableAsync.ToDictionaryAsync(queryable, keySelector, elementSelector, cancellationToken);
        
        public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement, TEntity>(this IQueryable<TEntity> queryable, Func<TEntity, TKey> keySelector, Func<TEntity, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
            => QueryableAsyncFactory.QueryableAsync.ToDictionaryAsync(queryable, keySelector, elementSelector,comparer, cancellationToken);
        
        public static Task ForEachAsync<TEntity>(this IQueryable<TEntity> queryable, Action<TEntity> action, CancellationToken cancellationToken = default) 
            => QueryableAsyncFactory.QueryableAsync.ForEachAsync(queryable, action, cancellationToken);
    }
}
