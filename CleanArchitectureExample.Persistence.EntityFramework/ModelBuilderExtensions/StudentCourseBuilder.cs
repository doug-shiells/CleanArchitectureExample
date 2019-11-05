using CleanArchitectureExample.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureExample.Persistence.EntityFramework.ModelBuilderExtensions
{
    internal static class StudentCourseBuilder
    {
        internal static void BuildStudentCourseRelationship(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                        .HasKey(sc => new { sc.StudentId, sc.CourseId });
            
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Courses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}
