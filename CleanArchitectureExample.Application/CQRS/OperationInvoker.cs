using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureExample.Application.CQRS
{
    //An alternative to this class is to inject command handler objects into your controllers
    internal class OperationInvoker : IOperationInvoker
    {
        private Func<ICommand, dynamic> resolveCommandHandler;
        private Func<ICommand, dynamic> resolveAsyncCommandHandler;
        private Func<IQuery, dynamic> resolveQueryExecutor;
        private Func<IQuery, dynamic> resolveAsyncQueryExecutor;

        public OperationInvoker(Func<ICommand, dynamic> commandHandlerResolver,
                                Func<ICommand, dynamic> asyncCommandHandlerResolver,
                                Func<IQuery, dynamic> queryExecutorResolver,
                                Func<IQuery, dynamic> asyncQueryExecutorResolver)
        {
            resolveCommandHandler = commandHandlerResolver;
            resolveAsyncCommandHandler = asyncCommandHandlerResolver;
            resolveQueryExecutor = queryExecutorResolver;
            resolveAsyncQueryExecutor = asyncQueryExecutorResolver;
        }

        public CommandResult Invoke(ICommand command)
        {
            var handler = resolveCommandHandler(command);
            List<ValidationResult> valiationErrors = handler.ValidateCommand((dynamic)command);

            return valiationErrors.Any() 
                ? new CommandResult(valiationErrors) 
                : handler.Handle((dynamic)command);
        }

        public async Task<CommandResult> InvokeAsync(ICommand command)
        {
            var handler = resolveAsyncCommandHandler(command);
            List<ValidationResult> valiationErrors = await handler.ValidateCommandAsync((dynamic)command);

            return valiationErrors.Any()
                ? new CommandResult(valiationErrors)
                : await handler.HandleAsync((dynamic)command);
        }
        
        public TQueryResult RunQuery<TQueryResult>(IQuery<TQueryResult> query)
        {
            return resolveQueryExecutor(query).ExecuteQuery((dynamic)query);
        }

        public async Task<TQueryResult> RunQueryAsync<TQueryResult>(IQuery<TQueryResult> query)
        {
            return await resolveAsyncQueryExecutor(query).ExecuteQueryAsync((dynamic)query);
        }
    }
}
