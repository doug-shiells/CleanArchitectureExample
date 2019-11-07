using System;
using System.Collections;
using System.Collections.Generic;

namespace CleanArchitectureExample.Domain
{
    public class Course
    {
        public Guid PublicKey { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int RequiredUnitCount { get; set; }

        public virtual ICollection<StudentCourse> Students { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}
