using CleanArchitectureExample.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureExample.Persistence.EntityFramework.ModelBuilderExtensions
{
    internal static class StudentBuilder
    {
        internal static void BuildStudent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                        .HasKey(s => s.StudentId);

            modelBuilder.Entity<Student>()
                        .Property(s => s.Firstname)
                        .HasMaxLength(128)
                        .IsRequired();

            modelBuilder.Entity<Student>()
                        .Property(s => s.Surname)
                        .HasMaxLength(128)
                        .IsRequired();

            modelBuilder.Entity<Student>()
                        .Property(s => s.DateOfBirth)
                        .IsRequired();

            modelBuilder.Entity<Student>()
                .HasAlternateKey(c => c.PublicKey)
                .HasName("IX_Student_PublicKey_Unique");

            modelBuilder.Entity<Student>()
                .Property(e => e.PublicKey)
                .ValueGeneratedOnAdd();
        }
    }
}
