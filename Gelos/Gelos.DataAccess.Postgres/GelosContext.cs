using Gelos.DataAccess.Postgres.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gelos.DataAccess.Postgres
{
    public class GelosContext : DbContext
    {
        public GelosContext(DbContextOptions<GelosContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<EmployeeDto> Employees { get; set; }

        public DbSet<IssueDto> Issues { get; set; }
    }
}