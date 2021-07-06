using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureExample.Application.Persistence.Extensions
{
    /// <summary>
    /// These extension methods are used to call the related async methods from
    /// Your implementation of of <see cref="Persistence.IQueryableExtensions"/> that will call the related async methods from your ORM
    /// This seems a little convoluted but it allows us to use the Async Queryable extensions for DB calls without
    /// a dependency on .net core (or another ORM) outside of our persistence DLL
    /// </summary>
    public static class IQueryableExtensions
    {
        public static Task<List<TEntity>> ToListAsync<TEntity>(this IQueryable<TEntity> queryable,
            CancellationToken cancellationToken = default)
            => QuerableExtensionsFactory.QueryableExtensions.ToListAsync(queryable, cancellationToken);

        public static Task<TEntity[]> ToArrayAsync<TEntity>(this IQueryable<TEntity> queryable, CancellationToken cancellationToken = default)
            => QuerableExtensionsFactory.QueryableExtensions.ToArrayAsync(queryable, cancellationToken);

        public static Task LoadAsync<TEntity>(this IQueryable<TEntity> queryable, CancellationToken cancellationToken = default) 
            => QuerableExtensionsFactory.QueryableExtensions.LoadAsync(queryable, cancellationToken);
        
        public static Task<Dictionary<TKey, TEntity>> ToDictionaryAsync<TKey, TEntity>(this IQueryable<TEntity> queryable, Func<TEntity, TKey> keySelector, CancellationToken cancellationToken = default)
            => QuerableExtensionsFactory.QueryableExtensions.ToDictionaryAsync(queryable, keySelector, cancellationToken);
        
        public static Task<Dictionary<TKey, TEntity>> ToDictionaryAsync<TKey, TEntity>(this IQueryable<TEntity> queryable, Func<TEntity, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
            => QuerableExtensionsFactory.QueryableExtensions.ToDictionaryAsync(queryable, keySelector, comparer, cancellationToken);
        
        public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement, TEntity>(this IQueryable<TEntity> queryable, Func<TEntity, TKey> keySelector, Func<TEntity, TElement> elementSelector, CancellationToken cancellationToken = default)
            => QuerableExtensionsFactory.QueryableExtensions.ToDictionaryAsync(queryable, keySelector, elementSelector, cancellationToken);
        
        public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement, TEntity>(this IQueryable<TEntity> queryable, Func<TEntity, TKey> keySelector, Func<TEntity, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
            => QuerableExtensionsFactory.QueryableExtensions.ToDictionaryAsync(queryable, keySelector, elementSelector,comparer, cancellationToken);
        
        public static Task ForEachAsync<TEntity>(this IQueryable<TEntity> queryable, Action<TEntity> action, CancellationToken cancellationToken = default) 
            => QuerableExtensionsFactory.QueryableExtensions.ForEachAsync(queryable, action, cancellationToken);

        public static IIncludableQueryable<TEntity, TProperty> Include<TEntity, TProperty>(this IQueryable<TEntity> queryable, Expression<Func<TEntity, TProperty>> navigationPropertyPath) where TEntity : class
            => QuerableExtensionsFactory.QueryableExtensions.Include(queryable, navigationPropertyPath);


        public static IIncludableQueryable<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(this
            IIncludableQueryable<TEntity, IEnumerable<TPreviousProperty>> source,
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
            where TEntity : class
            => QuerableExtensionsFactory.QueryableExtensions.ThenInclude(source, navigationPropertyPath);

        public static IIncludableQueryable<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
            this IIncludableQueryable<TEntity, TPreviousProperty> source,
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
            where TEntity : class
            => QuerableExtensionsFactory.QueryableExtensions.ThenInclude(source, navigationPropertyPath);

    }
}
