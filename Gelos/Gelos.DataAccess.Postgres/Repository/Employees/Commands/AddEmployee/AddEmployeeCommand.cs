using MediatR;


namespace Gelos.DataAccess.Postgres.Repository.Employees.Commands.AddEmployee
{
    public class AddEmployeeCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }

        public string Name { get; set; } = String.Empty;
    }
}
