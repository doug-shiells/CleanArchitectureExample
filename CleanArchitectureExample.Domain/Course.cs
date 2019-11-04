using System;

namespace CleanArchitectureExample.Domain
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int RequiredUnitCount { get; set; }
    }
}
