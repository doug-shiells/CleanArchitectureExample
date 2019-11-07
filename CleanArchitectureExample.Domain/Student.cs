using System;
using System.Collections;
using System.Collections.Generic;

namespace CleanArchitectureExample.Domain
{
    public class Student
    {
        public Guid PublicKey { get; set; }
        public int StudentId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<StudentCourse> Courses { get; set; }
    }
}
