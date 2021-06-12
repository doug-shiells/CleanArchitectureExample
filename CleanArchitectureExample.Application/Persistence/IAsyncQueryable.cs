﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureExample.Application.Persistence
{
    public interface IAsyncQueryable<TEntity> : IQueryable<TEntity>
    {
        Task<List<TEntity>> ToListAsync(CancellationToken cancellationToken = default);

        Task<TEntity[]> ToArrayAsync(CancellationToken cancellationToken = default);

        Task LoadAsync(CancellationToken cancellationToken = default);

        Task<Dictionary<TKey, TEntity>> ToDictionaryAsync<TKey>(Func<TEntity, TKey> keySelector, CancellationToken cancellationToken = default);

        Task<Dictionary<TKey, TEntity>> ToDictionaryAsync<TKey>(Func<TEntity, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default);

        Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement>(Func<TEntity, TKey> keySelector, Func<TEntity, TElement> elementSelector, CancellationToken cancellationToken = default);

        Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement>(Func<TEntity, TKey> keySelector, Func<TEntity, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default);

        Task ForEachAsync(Action<TEntity> action, CancellationToken cancellationToken = default);
    }


    public interface IQueryableAsync
    {
        Task<List<TEntity>> ToListAsync<TEntity>(IQueryable<TEntity> queryable, CancellationToken cancellationToken = default);

        Task<TEntity[]> ToArrayAsync<TEntity>(IQueryable<TEntity> queryable, CancellationToken cancellationToken = default);

        Task LoadAsync<TEntity>(IQueryable<TEntity> queryable, CancellationToken cancellationToken = default);

        Task<Dictionary<TKey, TEntity>> ToDictionaryAsync<TKey, TEntity>(IQueryable<TEntity> queryable, Func<TEntity, TKey> keySelector, CancellationToken cancellationToken = default);

        Task<Dictionary<TKey, TEntity>> ToDictionaryAsync<TKey, TEntity>(IQueryable<TEntity> queryable, Func<TEntity, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default);

        Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement, TEntity>(IQueryable<TEntity> queryable, Func<TEntity, TKey> keySelector, Func<TEntity, TElement> elementSelector, CancellationToken cancellationToken = default);

        Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement, TEntity>(IQueryable<TEntity> queryable, Func<TEntity, TKey> keySelector, Func<TEntity, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default);

        Task ForEachAsync<TEntity>(IQueryable<TEntity> queryable, Action<TEntity> action, CancellationToken cancellationToken = default);
    }
}
