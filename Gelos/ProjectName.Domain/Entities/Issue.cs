
namespace Gelos.Domain.Entities
{
    public class Issue : BaseEntity
    {
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
        public Employee Provider { get; set; }
        public Employee Executor { get; set; }
        public List<СalcFile>? Files { get; set; }

        public Issue(string name, Employee provider) : base()
        {
            Name = name;
            CreateDate = DateTime.Now;
            Provider = provider;
        }
    }
}
