using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CleanArchitectureExample.Domain;

namespace CleanArchitectureExample.Application.Students.Queries
{
    public static class StudentQueries
    {
        public static Func<Student, string, bool> GetStudentBySurname = (student, name) => student.Surname == name;
    }
}
