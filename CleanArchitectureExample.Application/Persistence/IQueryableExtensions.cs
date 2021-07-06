using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureExample.Application.Persistence
{
    public interface IQueryableExtensions
    {
        Task<List<TEntity>> ToListAsync<TEntity>(IQueryable<TEntity> queryable, CancellationToken cancellationToken = default);

        Task<TEntity[]> ToArrayAsync<TEntity>(IQueryable<TEntity> queryable, CancellationToken cancellationToken = default);

        Task LoadAsync<TEntity>(IQueryable<TEntity> queryable, CancellationToken cancellationToken = default);

        Task<Dictionary<TKey, TEntity>> ToDictionaryAsync<TKey, TEntity>(IQueryable<TEntity> queryable, Func<TEntity, TKey> keySelector, CancellationToken cancellationToken = default);

        Task<Dictionary<TKey, TEntity>> ToDictionaryAsync<TKey, TEntity>(IQueryable<TEntity> queryable, Func<TEntity, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default);

        Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement, TEntity>(IQueryable<TEntity> queryable, Func<TEntity, TKey> keySelector, Func<TEntity, TElement> elementSelector, CancellationToken cancellationToken = default);

        Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement, TEntity>(IQueryable<TEntity> queryable, Func<TEntity, TKey> keySelector, Func<TEntity, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default);

        Task ForEachAsync<TEntity>(IQueryable<TEntity> queryable, Action<TEntity> action, CancellationToken cancellationToken = default);

        IIncludableQueryable<TEntity, TProperty> Include<TEntity, TProperty>(IQueryable<TEntity> queryable, Expression<Func<TEntity, TProperty>> navigationPropertyPath) where TEntity : class;

        IIncludableQueryable<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
            IIncludableQueryable<TEntity, IEnumerable<TPreviousProperty>> source,
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
            where TEntity : class;

        IIncludableQueryable<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
            IIncludableQueryable<TEntity, TPreviousProperty> source,
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
            where TEntity : class;
    }

    public interface IIncludableQueryable<out TEntity, out TProperty> : IQueryable<TEntity>, IEnumerable<TEntity>, IEnumerable, IQueryable { }

}
