using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CleanArchitectureExample.Application.CQRS
{
    //An alternative to this class is to inject command handler objects into your controllers
    internal class OperationInvoker : IOperationInvoker
    {
        private Func<ICommand, dynamic> resolveCommandHandler;
        private Func<IQuery, dynamic> resolveQueryExecutor;

        public OperationInvoker(Func<ICommand, dynamic> commandHandlerResolver,
                              Func<IQuery, dynamic> queryExecutorResolver)
        {
            resolveCommandHandler = commandHandlerResolver;
            resolveQueryExecutor = queryExecutorResolver;
        }

        public CommandResult Invoke(ICommand command)
        {
            var handler = resolveCommandHandler(command);
            List<ValidationResult> valiationErrors = handler.ValidateCommand((dynamic)command);

            return valiationErrors.Any() 
                ? new CommandResult(valiationErrors) 
                : handler.Handle((dynamic)command);
        }

        public TQueryResult RunQuery<TQueryResult>(IQuery<TQueryResult> query)
        {
            return resolveQueryExecutor(query).ExecuteQuery((dynamic)query);
        }
    }
}
