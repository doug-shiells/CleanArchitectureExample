using CleanArchitectureExample.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureExample.Persistence.EntityFramework.ModelBuilderExtensions
{
    internal static class CourseBuilder
    {
        internal static void BuildCourses(this ModelBuilder modelBuilder)
        {
            //Using fluent extensions over data attributes
            //prevents the need to have dependency to EF in the domain project
            modelBuilder.Entity<Course>()
                        .HasKey(s => s.CourseId);

            modelBuilder.Entity<Course>()
                        .Property(s => s.CourseName)
                        .HasColumnName("Name")
                        .HasMaxLength(128)
                        .IsRequired();

            modelBuilder.Entity<Course>()
                        .Property(s => s.RequiredUnitCount)
                        .IsRequired();
        }
    }
}
