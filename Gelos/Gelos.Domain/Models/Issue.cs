
using CSharpFunctionalExtensions;

namespace Gelos.Domain.Models
{
    public record Issue
    {
        public const int MAX_NAME_LENGHT = 500;

        private Issue(string name, string? description, DateTime createDate)
        {
            Name = name;
            Description = description;
            CreateDate = createDate;
        }

        public long Id { get; init; }

        public string Name { get; }

        public string? Description { get; }

        public DateTime CreateDate { get; set; }

        public DateTime EndDate { get; set; }

        public Employee? Provider { get; set; }

        public Employee? Executor { get; set; }

        public static Result<Issue> Create(string name, string? description, DateTime createDate)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<Issue>("Name must have value");
            }
            if (name.Length > MAX_NAME_LENGHT)
            {
                return Result.Failure<Issue>($"Name should be less then {MAX_NAME_LENGHT} symbols");
            }

            return new Issue(name, description, createDate);
        }

        // public List<СalcFile>? Files { get; set; }
    }
}
