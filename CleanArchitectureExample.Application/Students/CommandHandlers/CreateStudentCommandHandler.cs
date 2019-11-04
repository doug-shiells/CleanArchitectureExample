using System;
using System.Collections.Generic;
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

        public void Handle(CreateStudentCommand command)
        {
            studentRepository.Insert(command.Student);
            studentRepository.SaveChanges();
        }
    }
}
