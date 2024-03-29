﻿using CSharpFunctionalExtensions;
using Gelos.DataAccess.Postgres.Entities;
using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gelos.DataAccess.Postgres.Repository
{
    public class EmployeeRepository : BaseRepository<Employee, EmployeeDto>, IRepository<Employee>
    {
        public EmployeeRepository(GelosContext context) : base(context) { }

        protected override EmployeeDto CreateEntityInstance(Employee model)
        {
            return new EmployeeDto
            {
                Id = model.Id,
                Name = model.Name,
                Role = model.Role
            };
        }

        protected override Result<Employee> CreateModel(EmployeeDto entity)
        {
           return Employee.Create(entity.Name, entity.Role, entity.Id); 
        }
    }
}
