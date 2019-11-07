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

            modelBuilder.Entity<Course>()
                .HasAlternateKey(c => c.PublicKey)
                .HasName("IX_Course_PublicKey_Unique");

            modelBuilder.Entity<Course>()
                .Property(e => e.PublicKey)
                .ValueGeneratedOnAdd();
        }
    }
}
