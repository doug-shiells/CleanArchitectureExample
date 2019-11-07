using CleanArchitectureExample.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureExample.Persistence.EntityFramework.ModelBuilderExtensions
{
    internal static class UnitBuilder
    {
        internal static void BuildUnits(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>()
                        .HasKey(e => e.UnitId);

            modelBuilder.Entity<Unit>()
                        .Property(e => e.UnitName)
                        .HasMaxLength(128)
                        .IsRequired();

            modelBuilder.Entity<Unit>()
                .HasAlternateKey(e => e.PublicKey)
                .HasName("IX_Unit_PublicKey_Unique");

            modelBuilder.Entity<Unit>()
                .Property(e => e.PublicKey)
                .ValueGeneratedOnAdd(); 
        }
    }
}
