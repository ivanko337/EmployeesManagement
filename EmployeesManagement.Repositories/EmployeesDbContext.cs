using EmployeesManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesManagement.Data
{
    public class EmployeesDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }

        public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeePosition>()
                .HasKey(ep => new { ep.EmployeeId, ep.PositionId });

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Positions)
                .WithMany(p => p.Employees)
                .UsingEntity<EmployeePosition>(
                    employee => employee
                        .HasOne(e => e.Position)
                        .WithMany(e => e.EmployeePositions)
                        .HasForeignKey(ep => ep.PositionId),
                    position => position
                        .HasOne(p => p.Employee)
                        .WithMany(e => e.EmployeePositions)
                        .HasForeignKey(ep => ep.EmployeeId));

            modelBuilder.Entity<Position>()
                .Property(p => p.Grade)
                .HasDefaultValue(1)
                .HasMaxLength(2)
                .HasAnnotation("Range", new[] { 1, 15 });
        }
    }
}
