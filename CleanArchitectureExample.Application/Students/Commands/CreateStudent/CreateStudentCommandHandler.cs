using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CleanArchitectureExample.Application.CQRS;
using CleanArchitectureExample.Application.Infrastructure;
using CleanArchitectureExample.Application.Persistence;
using CleanArchitectureExample.Domain;

namespace CleanArchitectureExample.Application.Students.Commands.CreateStudent
{
    internal class CreateStudentCommandHandler : ICommandHandler<CreateStudentCommand>
    {
        private readonly IEntityRepository<Student> studentRepository;
        private readonly IClock clock;

        public CreateStudentCommandHandler(IEntityRepository<Student> studentRepository,
                                           IClock clock)
        {
            this.studentRepository = studentRepository ?? throw new ArgumentException(nameof(studentRepository));
            this.clock = clock ?? throw new ArgumentException(nameof(clock));
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

            if(command.Student.DateOfBirth >= clock.Now)
            {
                validationErrors.Add(new ValidationResult("Date of birth cannot be in the future", new[] { $"{nameof(command.Student)}{nameof(command.Student.DateOfBirth)}" }));
            }

            return validationErrors;
        }
    }
}
