using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArchitectureExample.Application.CQRS
{
    internal interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        CommandResult Handle(TCommand command);
        List<ValidationResult> ValidateCommand(TCommand command);
    }
}
