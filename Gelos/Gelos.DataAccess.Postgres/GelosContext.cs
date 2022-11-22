using Gelos.DataAccess.Postgres.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gelos.DataAccess.Postgres
{
    public sealed class GelosContext : DbContext
    {
        static GelosContext()
        {
        }
        
        public GelosContext(DbContextOptions<GelosContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GelosContext).Assembly);
        }

        public DbSet<EmployeeDto>? Employees { get; set; }

        public DbSet<IssueDto>? Issues { get; set; }
    }
}