
namespace Gelos.DataAccess.Json.Entityes
{
    public class IssueDto
    {
        public int Id { get; init; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime EndDate { get; set; }

        public EmployeeDto? Provider { get; set; }

        public EmployeeDto? Executor { get; set; }
    }
}
