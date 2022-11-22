using Gelos.Domain.Models;

namespace Gelos.Domain.Interfaces
{
    public interface IEmployeeService : IService<Employee>
    {
        public Task<CSharpFunctionalExtensions.Result> Create(string name, Role role);
    }
}
