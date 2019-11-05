using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureExample.Application.CQRS
{
    //An alternative to this class is to inject command handler objects into your controllers
    internal class CommandInvoker : ICommandInvoker
    {
        private Func<ICommand, dynamic> resolveCommandHandler;
        private Func<IQuery, dynamic> resolveQueryExecutor;

        public CommandInvoker(Func<ICommand, dynamic> commandHandlerResolver,
                              Func<IQuery, dynamic> queryExecutorResolver)
        {
            resolveCommandHandler = commandHandlerResolver;
            resolveQueryExecutor = queryExecutorResolver;
        }

        public void Invoke(ICommand command)
        {
            resolveCommandHandler(command).Handle((dynamic)command);
        }

        public TQueryResult RunQuery<TQueryResult>(IQuery<TQueryResult> query)
        {
            return resolveQueryExecutor(query).ExecuteQuery((dynamic)query);
        }
    }
}
