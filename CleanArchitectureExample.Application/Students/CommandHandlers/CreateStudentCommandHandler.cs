using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CleanArchitectureExample.Application.CQRS;
using CleanArchitectureExample.Application.Persistence;
using CleanArchitectureExample.Application.Students.Commands;
using CleanArchitectureExample.Domain;

namespace CleanArchitectureExample.Application.Students.CommandHandlers
{
    internal class CreateStudentCommandHandler : ICommandHandler<CreateStudentCommand>
    {
        private readonly IEntityRepository<Student> studentRepository;

        public CreateStudentCommandHandler(IEntityRepository<Student> studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public CommandResult Handle(CreateStudentCommand command)
        {
            studentRepository.Insert(command.Student);
            studentRepository.SaveChanges();

            return new CommandResult(CommandOutcome.Success);
        }

        public List<ValidationResult> ValidateCommand(CreateStudentCommand command)
        {
            var validationErrors = new List<ValidationResult>();
            if (studentRepository.Entities.Any(s => s.PublicKey == command.Student.PublicKey))
            {
                validationErrors.Add(new ValidationResult("Student already exists with given public key", new[]{$"{nameof(command.Student)}{nameof(command.Student.StudentId)}"}));
            }

            return validationErrors;
        }
    }
}
