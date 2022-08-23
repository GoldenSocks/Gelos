using CSharpFunctionalExtensions;
using Gelos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gelos.Domain.Interfaces
{
    public interface IEmployeeService : IService<Employee>
    {
        public Task<Result> Create(string name, Role role);
    }
}
