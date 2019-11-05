using System;

namespace CleanArchitectureExample.Application.Students.Queries.GetStudentGithub
{
    public class StudentGithubDto
    {
        public string Login { get; }
        public int Id { get; }

        public StudentGithubDto(int id, string login)
        {
            Login = login ?? throw new ArgumentNullException(nameof(login));
            Id = id;
        }
    }
}
