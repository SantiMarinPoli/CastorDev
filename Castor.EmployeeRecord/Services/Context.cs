using Castor.EmployeeRecord.Models;
using Microsoft.EntityFrameworkCore;

namespace Castor.EmployeeRecord.Services
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(p => p.id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Position>().HasData(
                new Position { idPosition = 1, name = "Scrum Master" },
                new Position { idPosition = 2, name = "Desarrollador" },
                new Position { idPosition = 3, name = "QA" },
                new Position { idPosition = 4, name = "PO" }
                );
        }
    }
}
