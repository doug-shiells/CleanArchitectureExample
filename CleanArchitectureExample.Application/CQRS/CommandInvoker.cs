using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureExample.Application.CQRS
{
    //An alternative to this class is to use MediatR https://github.com/jbogard/MediatR
    //or inject command handler objects into your controllers
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
