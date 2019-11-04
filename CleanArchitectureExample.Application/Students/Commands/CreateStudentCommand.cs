using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitectureExample.Application.CQRS;
using CleanArchitectureExample.Domain;

namespace CleanArchitectureExample.Application.Students.Commands
{
    public class CreateStudentCommand : ICommand
    {
        public Student Student { get; }

        public CreateStudentCommand(Student student)
        {
            Student = student;
        }
    }
}
