using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using CleanArchitectureExample.Application.Persistence;
using CleanArchitectureExample.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CleanArchitectureExample.Persistence.EntityFramework
{
    internal class EntityRepository<TEntity> : IEntityRepository<TEntity>, IQueryable<TEntity> where TEntity : class
    {
        private readonly CleanArchitectureExampleContext context;
        private readonly DbSet<TEntity> entities;

        public EntityRepository(CleanArchitectureExampleContext context)
        {
            this.context = context;
            this.entities = context.Set<TEntity>();
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

        public IEnumerator<TEntity> GetEnumerator()
            => entities.AsNoTracking().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => entities.AsNoTracking().GetEnumerator();
        public Type ElementType => entities.AsNoTracking().ElementType;
        public Expression Expression => entities.AsNoTracking().Expression;
        public IQueryProvider Provider => entities.AsNoTracking().Provider;
    }
}
