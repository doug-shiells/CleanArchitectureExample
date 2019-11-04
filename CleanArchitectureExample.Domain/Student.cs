using System;

namespace CleanArchitectureExample.Domain
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
