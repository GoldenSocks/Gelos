using Gelos.DataAccess.Postgres.Common.Exceptions;
using Gelos.DataAccess.Postgres.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Gelos.DataAccess.Postgres.Repository.Employees.Commands.UpdateNote
{
    public class UpdateEmployeeCommandHandler
        : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly GelosContext _context;

        public UpdateEmployeeCommandHandler(GelosContext context) =>
            _context = context;

        public async Task<Unit> Handle(UpdateEmployeeCommand requst,
            CancellationToken cancellationToken)
        {
            var employee =
                await _context.Employees.FirstOrDefaultAsync(employee =>
                employee.Id == requst.UserId, cancellationToken);

            if(employee == null || employee.Id != requst.UserId)
            {
                throw new NotFoundException(nameof(EmployeeDto), requst.UserId);
            }

            employee.Name = requst.Name;
            employee.Role = requst.UserRole;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
