using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArchitectureExample.Application.CQRS
{
    public sealed class CommandResult
    {
        public List<ValidationResult> ValidationErrors { get; }
        public CommandOutcome Outcome { get; }

        public CommandResult(List<ValidationResult> validationErrors) : this(CommandOutcome.Failed, validationErrors)
        {

        }

        public CommandResult(CommandOutcome outcome, List<ValidationResult> validationErrors = null)
        {
            ValidationErrors = validationErrors ?? new List<ValidationResult>();
            Outcome = outcome;
        }
    }
}
