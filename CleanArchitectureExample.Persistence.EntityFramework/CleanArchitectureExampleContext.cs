using System;
using CleanArchitectureExample.Domain;
using CleanArchitectureExample.Persistence.EntityFramework.ModelBuilderExtensions;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureExample.Persistence.EntityFramework
{
    internal class CleanArchitectureExampleContext : DbContext
    {
        public CleanArchitectureExampleContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=CleanArchitectureExampleDb;Trusted_Connection=True;Integrated Security=SSPI;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildStudent();
            modelBuilder.BuildCourses();
            modelBuilder.BuildStudentCourseRelationship();
            modelBuilder.BuildUnits();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}
