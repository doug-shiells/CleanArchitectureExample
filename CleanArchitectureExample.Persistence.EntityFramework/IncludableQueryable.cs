using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CleanArchitectureExample.Application.Persistence;

namespace CleanArchitectureExample.Persistence.EntityFramework
{
    internal class IncludableQueryable<TEntity, TProperty> : IIncludableQueryable<TEntity, TProperty>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<TEntity, TProperty>
    {
        private readonly IQueryable<TEntity> queryable;

        public IncludableQueryable(IQueryable<TEntity> queryable)
        {
            this.queryable = queryable;
        }
        
        public IEnumerator<TEntity> GetEnumerator() => queryable.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => queryable.GetEnumerator();

        public Type ElementType => queryable.ElementType;
        public Expression Expression => queryable.Expression;
        public IQueryProvider Provider => queryable.Provider;
    }
}
