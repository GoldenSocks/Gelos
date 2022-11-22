using CSharpFunctionalExtensions;

namespace Gelos.Domain.Models
{
    public record Issue
    {
        public const int MAX_NAME_LENGHT = 500;

        private Issue(long id, string name, string? description, DateTime createDate)
        {
            Id = id;
            Name = name;
            Description = description;
            CreateDate = createDate;
        }

        public long Id { get;}

        public string Name { get; private set; }

        public string? Description { get; private set; }

        public DateTime CreateDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public Employee? Provider { get; private set; }

        public Employee? Executor { get; private set; }

        public static Result<Issue> Create(string name, string? description, DateTime createDate, long id = 0)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return CSharpFunctionalExtensions.Result.Failure<Issue>("Name must have value");
            }
            
            if (name.Length > MAX_NAME_LENGHT)
            {
                return CSharpFunctionalExtensions.Result.Failure<Issue>($"Name should be less then {MAX_NAME_LENGHT} symbols");
            }

            return new Issue(id, name, description, createDate);
        }

        // public List<СalcFile>? Files { get; set; }
    }
}
