using CSharpFunctionalExtensions;
using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;

namespace Gelos.BusinessLogic.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(IRepository<Employee> repository) : base(repository)
        {
        }

        public async Task<Result> Create(string name, Role role)
        {
            var employee = Employee.Create(name, role);
            if (employee.IsSuccess)
                await _repository.AddAsync(employee.Value);
            return employee;
        }
    }
}
