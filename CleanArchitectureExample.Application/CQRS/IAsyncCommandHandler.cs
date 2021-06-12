using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CleanArchitectureExample.Application.CQRS
{
    internal interface IAsyncCommandHandler<in TCommand> where TCommand : ICommand
    {
        Task<CommandResult> HandleAsync(TCommand command);
        Task<List<ValidationResult>> ValidateCommandAsync(TCommand command);
    }
}