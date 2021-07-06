using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureExample.Application.Persistence;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;

namespace CleanArchitectureExample.Persistence.EntityFramework
{
    /// <summary>
    /// This class is used essentially as a proxy for the async IQueryable extensions provided by entity framework
    /// its intended use is to be a stateless singleton that is called by the extension methods defined in  <see cref="Application.Persistence.Extensions.IQueryableExtensions"/>
    /// </summary>
    internal class QueryableExtensions : IQueryableExtensions 
    {
        public Task<List<TEntity>> ToListAsync<TEntity>(IQueryable<TEntity> queryable, CancellationToken cancellationToken = default)
        {
            return queryable.ToListAsync(cancellationToken);
        }

        public Task<TEntity[]> ToArrayAsync<TEntity>(IQueryable<TEntity> queryable, CancellationToken cancellationToken = default)
        {
            return queryable.ToArrayAsync(cancellationToken);
        }

        public Task LoadAsync<TEntity>(IQueryable<TEntity> queryable, CancellationToken cancellationToken = default)
        {
            return queryable.LoadAsync(cancellationToken);
        }

        public Task<Dictionary<TKey, TEntity>> ToDictionaryAsync<TKey, TEntity>(IQueryable<TEntity> queryable, Func<TEntity, TKey> keySelector,
            CancellationToken cancellationToken = default)
        {
            return queryable.ToDictionaryAsync(keySelector, cancellationToken);
        }

        public Task<Dictionary<TKey, TEntity>> ToDictionaryAsync<TKey, TEntity>(IQueryable<TEntity> queryable, Func<TEntity, TKey> keySelector, IEqualityComparer<TKey> comparer,
            CancellationToken cancellationToken = default)
        {
            return queryable.ToDictionaryAsync(keySelector, comparer, cancellationToken);
        }

        public Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement, TEntity>(IQueryable<TEntity> queryable, Func<TEntity, TKey> keySelector, Func<TEntity, TElement> elementSelector,
            CancellationToken cancellationToken = default)
        {
            return queryable.ToDictionaryAsync(keySelector, elementSelector, cancellationToken);
        }

        public Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement, TEntity>(IQueryable<TEntity> queryable, Func<TEntity, TKey> keySelector, Func<TEntity, TElement> elementSelector,
            IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
        {
            return queryable.ToDictionaryAsync(keySelector, elementSelector, comparer, cancellationToken);
        }

        public Task ForEachAsync<TEntity>(IQueryable<TEntity> queryable, Action<TEntity> action, CancellationToken cancellationToken = default)
        {
            return queryable.ForEachAsync(action, cancellationToken);
        }

        public IIncludableQueryable<TEntity, TProperty> Include<TEntity, TProperty>(IQueryable<TEntity> queryable, Expression<Func<TEntity, TProperty>> navigationPropertyPath) where TEntity : class
        {
            return new IncludableQueryable<TEntity, TProperty>(queryable.Include(navigationPropertyPath));
        }

        public IIncludableQueryable<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
            IIncludableQueryable<TEntity, IEnumerable<TPreviousProperty>> source, 
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
            where TEntity : class
        {
            return new IncludableQueryable<TEntity, TProperty>(((Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<TEntity, IEnumerable<TPreviousProperty>>)source).ThenInclude(navigationPropertyPath));
        }

        public IIncludableQueryable<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
            IIncludableQueryable<TEntity, TPreviousProperty> source,
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
            where TEntity : class
        {
            return new IncludableQueryable<TEntity, TProperty>(((Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<TEntity, TPreviousProperty>)source).ThenInclude(navigationPropertyPath));
        }
    }
}
