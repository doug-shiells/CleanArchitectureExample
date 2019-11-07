using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureExample.Application.CQRS
{
    public interface ICommand
    {
    }

    public interface ICommand<TResult> : ICommand
    {
    }
}
