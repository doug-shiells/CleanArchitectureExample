using System;
using CleanArchitectureExample.Domain;

namespace CleanArchitectureExample.Application.Students.Queries
{
    public static class StudentQueries
    {
        public static Func<Student, string, bool> GetStudentBySurname = (student, name) => student.Surname == name;
    }
}
