using Gelos.Domain.Models;
using MediatR;


namespace Gelos.DataAccess.Postgres.Repository.Employees.Commands.UpdateNote
{
    public class UpdateEmployeeCommand : IRequest
    {
        public Guid UserId { get; set; }

        public string Name { get; set; } = String.Empty;

        public Role UserRole { get; set; }
    }
}
