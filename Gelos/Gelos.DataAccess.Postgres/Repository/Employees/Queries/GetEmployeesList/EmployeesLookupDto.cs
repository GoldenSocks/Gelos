using AutoMapper;
using Gelos.DataAccess.Postgres.Common.Mapping;
using Gelos.Domain.Models;


namespace Gelos.DataAccess.Postgres.Repository.Employees.Queries.GetEmployeesList
{
    public class EmployeesLookupDto : IMapWith<Employee>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Role Role { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeesLookupDto>();
        }
    }
}
