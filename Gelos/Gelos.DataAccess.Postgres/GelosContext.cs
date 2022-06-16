﻿using Gelos.DataAccess.Postgres.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gelos.DataAccess.Postgres
{
    public class GelosContext : DbContext
    {
        public GelosContext(DbContextOptions<GelosContext> options) : base(options)
        {
        }

        public DbSet<EmployeeDto> Employees { get; set; }

        public DbSet<IssueDto> Issues { get; set; }
    }
}