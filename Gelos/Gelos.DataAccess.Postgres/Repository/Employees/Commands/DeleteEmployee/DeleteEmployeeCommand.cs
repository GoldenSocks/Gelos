using MediatR;


namespace Gelos.DataAccess.Postgres.Repository.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest
    {
        public Guid UserId { get; set; }
    }
}
