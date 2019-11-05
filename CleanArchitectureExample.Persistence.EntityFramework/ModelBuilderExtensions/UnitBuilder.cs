using CleanArchitectureExample.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureExample.Persistence.EntityFramework.ModelBuilderExtensions
{
    internal static class UnitBuilder
    {
        internal static void BuildUnits(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>()
                        .HasKey(s => s.UnitId);

            modelBuilder.Entity<Unit>()
                        .Property(s => s.UnitName)
                        .HasMaxLength(128)
                        .IsRequired();
        }
    }
}
