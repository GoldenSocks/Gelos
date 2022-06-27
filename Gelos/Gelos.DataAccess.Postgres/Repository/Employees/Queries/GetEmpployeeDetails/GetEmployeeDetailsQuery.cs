using MediatR;


namespace Gelos.DataAccess.Postgres.Repository.Employees.Queries.GetEmpployeeDetails
{
    public class GetEmployeeDetailsQuery : IRequest<EmployeeDetails>
    {
        public Guid UserId { get; set; }
    }
}
