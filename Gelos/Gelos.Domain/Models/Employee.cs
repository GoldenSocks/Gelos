
namespace Gelos.Domain.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public Role Role { get; set; }
    }
}
