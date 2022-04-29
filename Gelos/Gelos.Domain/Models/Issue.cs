
namespace Gelos.Domain.Models
{
    public record Issue
    {
        private Issue(int id, string name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
            CreateDate = DateTime.Now;
        }

        public int Id { get; init; }

        public string Name { get; }

        public string? Description { get; }

        public DateTime CreateDate { get; set; }

        public DateTime EndDate { get; set; }

        public Employee Provider { get; set; }

        public Employee Executor { get; set; }

        public static (Issue? Result, string Error) Create(string name, string? description)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                return (null, "Name must have value");
            }
            if(name.Length > 500)
            {
                return (null, "Name should be less then 500");
            }

            return (new Issue(0, name, description), string.Empty);
        }

        // public List<СalcFile>? Files { get; set; }
    }
}
