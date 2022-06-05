using Gelos.DataAccess.Postgres.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gelos.DataAccess.Postgres
{
    public class GelosContext : DbContext
    {
        public DbSet<EmployeeDto> Employees { get; set; }

        public DbSet<IssueDto> Issues { get; set; }

        public GelosContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql();
        }
    }
}