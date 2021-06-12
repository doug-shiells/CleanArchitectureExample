using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureExample.Application.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureExample.Persistence.EntityFramework
{
    //internal class AsyncQueryable<TEntity> : IAsyncQueryable<TEntity> where TEntity : class
    //{
    //    private readonly CleanArchitectureExampleContext context;
    //    private readonly IQueryable<TEntity> entitiesAsNoTracking;
    //    private readonly DbSet<TEntity> entities;

    //    public AsyncQueryable(CleanArchitectureExampleContext context)
    //    {
    //        this.context = context;
    //        this.entities = context.Set<TEntity>();
    //        this.entitiesAsNoTracking = context.Set<TEntity>().AsNoTracking();
    //    }
        
    //    public IEnumerator<TEntity> GetEnumerator() 
    //        => entitiesAsNoTracking.GetEnumerator();

    //    IEnumerator IEnumerable.GetEnumerator() => entitiesAsNoTracking.GetEnumerator();
    //    public Type ElementType => entitiesAsNoTracking.ElementType;
    //    public Expression Expression => entitiesAsNoTracking.Expression;
    //    public IQueryProvider Provider => new AsyncQueryableProvider(entitiesAsNoTracking);
        
    //    public Task<List<TEntity>> ToListAsync(CancellationToken cancellationToken = default)
    //        => entitiesAsNoTracking.ToListAsync(cancellationToken);

    //    public Task<TEntity[]> ToArrayAsync(CancellationToken cancellationToken = default)
    //        => entitiesAsNoTracking.ToArrayAsync(cancellationToken);

    //    public Task LoadAsync(CancellationToken cancellationToken = default)
    //        => entitiesAsNoTracking.LoadAsync(cancellationToken);

    //    public Task<Dictionary<TKey, TEntity>> ToDictionaryAsync<TKey>(Func<TEntity, TKey> keySelector, CancellationToken cancellationToken = default)
    //        => entitiesAsNoTracking.ToDictionaryAsync(keySelector,cancellationToken);
        
    //    public Task<Dictionary<TKey, TEntity>> ToDictionaryAsync<TKey>(Func<TEntity, TKey> keySelector, IEqualityComparer<TKey> comparer,
    //        CancellationToken cancellationToken = default)
    //        => entitiesAsNoTracking.ToDictionaryAsync(keySelector, comparer, cancellationToken);

    //    public Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement>(Func<TEntity, TKey> keySelector, Func<TEntity, TElement> elementSelector,
    //        CancellationToken cancellationToken = default)
    //        => entitiesAsNoTracking.ToDictionaryAsync(keySelector, elementSelector, cancellationToken);

    //    public Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement>(Func<TEntity, TKey> keySelector, Func<TEntity, TElement> elementSelector, IEqualityComparer<TKey> comparer,
    //        CancellationToken cancellationToken = default)
    //        => entitiesAsNoTracking.ToDictionaryAsync(keySelector, elementSelector, comparer, cancellationToken);

    //    public Task ForEachAsync(Action<TEntity> action, CancellationToken cancellationToken = default)
    //        => entitiesAsNoTracking.ForEachAsync(action, cancellationToken);
    //}

    //internal class AsyncQueryableSubset<TEntity> : IAsyncQueryable<TEntity> where TEntity : class
    //{
    //    private readonly IQueryable<TEntity> queryable;

    //    public AsyncQueryableSubset(IQueryable<TEntity> queryable)
    //    {
    //        this.queryable = queryable;
    //    }

    //    public IEnumerator<TEntity> GetEnumerator()
    //        => queryable.GetEnumerator();

    //    IEnumerator IEnumerable.GetEnumerator() => queryable.GetEnumerator();
    //    public Type ElementType => queryable.ElementType;
    //    public Expression Expression => queryable.Expression;
    //    public IQueryProvider Provider => new AsyncQueryableProvider(queryable);

    //    public Task<List<TEntity>> ToListAsync(CancellationToken cancellationToken = default)
    //        => queryable.ToListAsync(cancellationToken);

    //    public Task<TEntity[]> ToArrayAsync(CancellationToken cancellationToken = default)
    //        => queryable.ToArrayAsync(cancellationToken);

    //    public Task LoadAsync(CancellationToken cancellationToken = default)
    //        => queryable.LoadAsync(cancellationToken);

    //    public Task<Dictionary<TKey, TEntity>> ToDictionaryAsync<TKey>(Func<TEntity, TKey> keySelector, CancellationToken cancellationToken = default)
    //        => queryable.ToDictionaryAsync(keySelector, cancellationToken);

    //    public Task<Dictionary<TKey, TEntity>> ToDictionaryAsync<TKey>(Func<TEntity, TKey> keySelector, IEqualityComparer<TKey> comparer,
    //        CancellationToken cancellationToken = default)
    //        => queryable.ToDictionaryAsync(keySelector, comparer, cancellationToken);

    //    public Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement>(Func<TEntity, TKey> keySelector, Func<TEntity, TElement> elementSelector,
    //        CancellationToken cancellationToken = default)
    //        => queryable.ToDictionaryAsync(keySelector, elementSelector, cancellationToken);

    //    public Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement>(Func<TEntity, TKey> keySelector, Func<TEntity, TElement> elementSelector, IEqualityComparer<TKey> comparer,
    //        CancellationToken cancellationToken = default)
    //        => queryable.ToDictionaryAsync(keySelector, elementSelector, comparer, cancellationToken);

    //    public Task ForEachAsync(Action<TEntity> action, CancellationToken cancellationToken = default)
    //        => queryable.ForEachAsync(action, cancellationToken);
    //}

    //internal class AsyncQueryableProvider<TEntity> : IQueryProvider where TEntity : class
    //{
    //    private readonly IQueryable referencedQueryable;

    //    public AsyncQueryableProvider(IQueryable referencedQueryable)
    //    {
    //        this.referencedQueryable = referencedQueryable ?? throw new ArgumentNullException(nameof(referencedQueryable));
    //    }

    //    public IQueryable CreateQuery(Expression expression)
    //    {
    //        return new AsyncQueryableSubset<TEntity>(referencedQueryable.Provider.CreateQuery(expression) as IQueryable<TEntity)
    //    }

    //    public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
    //    {
    //        return new AsyncQueryableSubset<TEntity>(referencedQueryable.Provider.CreateQuery<TEntity>(expression));
    //    }

    //    public object Execute(Expression expression)
    //    {
            
    //    }

    //    public TResult Execute<TResult>(Expression expression)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}


    internal class QueryableAsync : IQueryableAsync 
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
    }
}
