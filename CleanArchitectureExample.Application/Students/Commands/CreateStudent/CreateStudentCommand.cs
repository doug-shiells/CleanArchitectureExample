using CleanArchitectureExample.Application.CQRS;
using CleanArchitectureExample.Domain;

namespace CleanArchitectureExample.Application.Students.Commands.CreateStudent
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
