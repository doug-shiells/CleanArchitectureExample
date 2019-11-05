using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureExample.Application.CQRS
{
    public interface ICommandInvoker
    {
        void Invoke(ICommand command);
        TQueryResult RunQuery<TQueryResult>(IQuery<TQueryResult> query);
    }
}
