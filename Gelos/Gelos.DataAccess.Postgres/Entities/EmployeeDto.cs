
using Gelos.Domain.Models;

namespace Gelos.DataAccess.Postgres.Entities
{
    public class EmployeeDto : BaseEntity
    {
        public new Guid Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public Role Role { get; set; }
    }

}
