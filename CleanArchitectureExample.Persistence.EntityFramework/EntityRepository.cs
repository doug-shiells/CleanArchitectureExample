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
    internal class EntityRepository<TEntity> : IEntityRepository<TEntity>, IQueryable<TEntity> where TEntity : class
    {
        private readonly CleanArchitectureExampleContext context;
        private readonly IQueryable<TEntity> entitiesAsNoTracking;
        private readonly DbSet<TEntity> entities;

        public EntityRepository(CleanArchitectureExampleContext context)
        {
            this.context = context;
            this.entities = context.Set<TEntity>();
            this.entitiesAsNoTracking = context.Set<TEntity>().AsNoTracking();
        }

        public IQueryable<TEntity> Entities => entities;

        public void Remove(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                entities.Attach(entity);
            }
            entities.Remove(entity);
        }

        public void Insert(TEntity entity)
        {
            entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            entities.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void SaveChanges() => context.SaveChanges();

        public Task SaveChangesAsync() => context.SaveChangesAsync();

        public IEnumerator<TEntity> GetEnumerator()
            => entitiesAsNoTracking.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => entitiesAsNoTracking.GetEnumerator();
        public Type ElementType => entitiesAsNoTracking.ElementType;
        public Expression Expression => entitiesAsNoTracking.Expression;
        public IQueryProvider Provider => entitiesAsNoTracking.Provider;
        
        public Task<List<TEntity>> ToListAsync(CancellationToken cancellationToken = default)
            => entitiesAsNoTracking.ToListAsync(cancellationToken);

        public Task<TEntity[]> ToArrayAsync(CancellationToken cancellationToken = default)
            => entitiesAsNoTracking.ToArrayAsync(cancellationToken);

        public Task LoadAsync(CancellationToken cancellationToken = default)
            => entitiesAsNoTracking.LoadAsync(cancellationToken);

        public Task<Dictionary<TKey, TEntity>> ToDictionaryAsync<TKey>(Func<TEntity, TKey> keySelector, CancellationToken cancellationToken = default)
            => entitiesAsNoTracking.ToDictionaryAsync(keySelector,cancellationToken);
        
        public Task<Dictionary<TKey, TEntity>> ToDictionaryAsync<TKey>(Func<TEntity, TKey> keySelector, IEqualityComparer<TKey> comparer,
            CancellationToken cancellationToken = default)
            => entitiesAsNoTracking.ToDictionaryAsync(keySelector, comparer, cancellationToken);

        public Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement>(Func<TEntity, TKey> keySelector, Func<TEntity, TElement> elementSelector,
            CancellationToken cancellationToken = default)
            => entitiesAsNoTracking.ToDictionaryAsync(keySelector, elementSelector, cancellationToken);

        public Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement>(Func<TEntity, TKey> keySelector, Func<TEntity, TElement> elementSelector, IEqualityComparer<TKey> comparer,
            CancellationToken cancellationToken = default)
            => entitiesAsNoTracking.ToDictionaryAsync(keySelector, elementSelector, comparer, cancellationToken);

        public Task ForEachAsync(Action<TEntity> action, CancellationToken cancellationToken = default)
            => entitiesAsNoTracking.ForEachAsync(action, cancellationToken);


    }
}
