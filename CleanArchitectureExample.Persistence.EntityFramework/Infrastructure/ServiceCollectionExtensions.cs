using System.Linq;
using CleanArchitectureExample.Application.Persistence;
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

            serviceCollection.AddSingleton(typeof(IQueryableAsync), typeof(QueryableAsync));
            serviceCollection.AddScoped(typeof(IQueryable<>), typeof(EntityRepository<>));
            serviceCollection.AddScoped(typeof(IAsyncQueryable<>), typeof(EntityRepository<>));
            serviceCollection.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));


            return serviceCollection;
        }
    }
}
