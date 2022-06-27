
namespace Gelos.Domain.Models
{
    public record Issue
    {
        public const int MAX_NAME_LENGTH = 500;

        private Issue(int id, string name, string? description, DateTime createDate)
        {
            Id = id;
            Name = name;
            Description = description;
            CreateDate = createDate;
        }

        public int Id { get; init; }

        public string Name { get; }

        public string? Description { get; }

        public DateTime CreateDate { get; set; }

        public DateTime EndDate { get; set; }

        public Employee? Provider { get; set; }

        public Employee? Executor { get; set; }

        public static (Issue? Result, string Error) Create(string name, string? description, DateTime createDate, int id = 0)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                return (null, "Name must have value");
            }
            if(name.Length > MAX_NAME_LENGTH)
            {
                return (null, $"Name should be less then {MAX_NAME_LENGTH} symbols");
            }

            return (new Issue(id, name, description, createDate), string.Empty);
        }



        // public List<СalcFile>? Files { get; set; }
    }
}
