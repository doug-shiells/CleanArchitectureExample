using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureExample.Application.CQRS
{
    internal class CommandInvoker : ICommandInvoker
    {
        private Func<ICommand, dynamic> resolveCommandHandler;

        public CommandInvoker(Func<ICommand, dynamic> commandHandlerResolver)
        {
            resolveCommandHandler = commandHandlerResolver;
        }

        public void Invoke(ICommand command)
        {
            resolveCommandHandler(command).Handle((dynamic)command);
        }
    }
}
