using Gelos.DataAccess.Postgres.Entities;
using Gelos.Domain.Models;
using MediatR;

namespace Gelos.DataAccess.Postgres.Repository.Employees.Commands.AddEmployee
{
    public class AddEmployeeCommandHandler
        : IRequestHandler<AddEmployeeCommand, Guid>
    {
        private readonly GelosContext _context;

        public AddEmployeeCommandHandler(GelosContext context) =>
            _context = context;

        public async Task<Guid> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new EmployeeDto
            {
                Id = request.UserId,
                Name = request.Name,
                Role = Role.DefaultUser
            };

            await _context.Employees.AddAsync(employee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return employee.Id;
        }
    }
}
