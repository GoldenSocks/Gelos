using AutoMapper;
using Gelos.DataAccess.Postgres.Common.Mapping;
using Gelos.Domain.Models;


namespace Gelos.DataAccess.Postgres.Repository.Employees.Queries.GetEmpployeeDetails
{
    public class EmployeeDetails : IMapWith<Employee>
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Role Role { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDetails>();
        }
    }
}
