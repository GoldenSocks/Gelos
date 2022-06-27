using MediatR;


namespace Gelos.DataAccess.Postgres.Repository.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQuery : IRequest<EmployeesList>
    {
        public Guid UserId { get; set; }
    }
}
