using System;
using System.Collections;
using System.Collections.Generic;

namespace CleanArchitectureExample.Domain
{
    //This is unfortunatly a little bit ugly
    //EF Core, unlike EF6, does not support 
    //many to many mappings without an explicit mapping table
    //In my opinion we are now leaking EF implementation detail
    //into our domain, which is bad...
    //hopefully soon this can be resolved and we wont need these 
    //tables in our domain
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
