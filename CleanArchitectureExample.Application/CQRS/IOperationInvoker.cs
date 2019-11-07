using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureExample.Application.CQRS
{
    public interface IOperationInvoker
    {
        CommandResult Invoke(ICommand command);
        TQueryResult RunQuery<TQueryResult>(IQuery<TQueryResult> query);
    }
}
