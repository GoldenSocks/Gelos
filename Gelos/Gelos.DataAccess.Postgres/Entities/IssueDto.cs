namespace Gelos.DataAccess.Postgres.Entities
{
    public class IssueDto : BaseEntity
    {

        public string Name { get; set; } = String.Empty;

        public string? Description { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime EndDate { get; set; }

        public EmployeeDto? Provider { get; set; }

        public EmployeeDto? Executor { get; set; }
    }
}
