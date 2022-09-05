using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;

namespace Gelos.Domain.Models
{
    public class Employee
    {
        private Employee(string name, Role role, long id)
        {
            Name = name;
            Role = role;
            Id = id;
        }

        public long Id { get;}

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Name cannot be null or empty")]  может атрибутами валидировать свойства?
        public string Name { get; set; } = String.Empty;

        public Role Role { get; set; }

        public static Result<Employee> Create(string name, Role role, long id = 0)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Employee>("Name cannot be null or empty");

            return new Employee(name, role, id);
        }


    }
}
