using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using CleanArchitectureExample.Application.CQRS;
using CleanArchitectureExample.Application.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureExample.Application.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        private static readonly Func<IServiceProvider, Func<ICommand, dynamic>> commandHanlderResolverFactory = 
            (serviceProvider) => 
                (command) => 
                    (dynamic) serviceProvider.GetService(typeof(ICommandHandler<>)
                                             .MakeGenericType(command.GetType()));

        private static readonly Func<IServiceProvider, Func<IQuery, dynamic>> queryExecuterResolverFactory =
            (serviceProvider) =>
                (query) =>
                    (dynamic) serviceProvider.GetService(
                        typeof(IQueryExecutor<,>).MakeGenericType(
                            query.GetType(),
                            query.GetType()
                                 .GetInterfaces()
                                 .Single(i =>
                                     i.IsGenericType
                                     && i.GetGenericTypeDefinition() == typeof(IQuery<>))
                                 .GetGenericArguments()[0]));

        public static IServiceCollection RegisterCommands(this IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterCommandHandlers()
                             .RegisterQueryExecutors()
                             .RegisterOperationInvoker();

            return serviceCollection;
        }
        public static IServiceCollection RegisterIClock(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSingleton<IClock, Clock>();
        }

        private static IServiceCollection RegisterCommandHandlers(this IServiceCollection serviceCollection)
        {

            var commandHandlers =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => !t.IsAbstract && !t.IsInterface
                                              && t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)));

            foreach (var type in commandHandlers)
            {

                serviceCollection.AddTransient(
                    type.GetInterfaces()
                        .Single(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)),
                    type);
            }

            return serviceCollection;
        }

        private static IServiceCollection RegisterQueryExecutors(this IServiceCollection serviceCollection)
        {
            var queryExecutors =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => !t.IsAbstract && !t.IsInterface
                                              && t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQueryExecutor<,>)));

            foreach (var type in queryExecutors)
            {
                serviceCollection.AddTransient(
                    type.GetInterfaces()
                        .Single(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQueryExecutor<,>)),
                    type);
            }

            return serviceCollection;
        }

        private static IServiceCollection RegisterOperationInvoker(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddTransient<IOperationInvoker>(
                (serviceProvider) =>
                    new OperationInvoker(commandHanlderResolverFactory(serviceProvider),
                        queryExecuterResolverFactory(serviceProvider)));
        }
    }
}
