using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CleanArchitectureExample.Application.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureExample.Persistence.EntityFramework.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddDbContext<CleanArchitectureExampleContext>(ServiceLifetime.Scoped);
            serviceCollection.AddScoped<ITransactionFactory, TransactionFactory>();
            serviceCollection.AddTransient<ITransaction, Transaction>();

            var entities = 
                typeof(CleanArchitectureExampleContext)
                    .GetProperties()
                    .Where(p => p.PropertyType.IsGenericType 
                             && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .Select(dbsetType => dbsetType.PropertyType.GetGenericArguments().Single());
                

            foreach (var entity in entities)
            {
                serviceCollection.AddScoped(
                    typeof(IEntityRepository<>).MakeGenericType(entity),
                    typeof(EntityRepository<>).MakeGenericType(entity));
                serviceCollection.AddScoped(
                    typeof(IQueryable<>).MakeGenericType(entity),
                    typeof(EntityRepository<>).MakeGenericType(entity));
            }
            
            return serviceCollection;
        }
    }
}
