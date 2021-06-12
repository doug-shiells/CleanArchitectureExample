using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureExample.Application.CQRS
{
    public interface IOperationInvoker
    {
        CommandResult Invoke(ICommand command);
        Task<CommandResult> InvokeAsync(ICommand command);
        TQueryResult RunQuery<TQueryResult>(IQuery<TQueryResult> query);
        Task<TQueryResult> RunQueryAsync<TQueryResult>(IQuery<TQueryResult> query);
    }
}
