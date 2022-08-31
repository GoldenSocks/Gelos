using CSharpFunctionalExtensions;
using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                await _Repository.AddAsync(employee.Value);
            return employee;
        }
    }
}
