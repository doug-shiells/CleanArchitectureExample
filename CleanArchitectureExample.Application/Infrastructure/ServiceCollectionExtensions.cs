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
        public static IServiceCollection RegisterCommands(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICommandInvoker>(
                (serviceProvider) => 
                    new CommandInvoker(
                        (command) => 
                        (dynamic) serviceProvider.GetService(typeof(ICommandHandler<>).MakeGenericType(command.GetType())),
                        (query) => 
                        (dynamic)serviceProvider.GetService(
                            typeof(IQueryExecutor<,>).MakeGenericType(
                                query.GetType(), 
                                query.GetType()
                                     .GetInterfaces()
                                     .Single(i => 
                                            i.IsGenericType 
                                         && i.GetGenericTypeDefinition() == typeof(IQuery<>))
                                     .GetGenericArguments()[0]))));

            
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
    }
}
