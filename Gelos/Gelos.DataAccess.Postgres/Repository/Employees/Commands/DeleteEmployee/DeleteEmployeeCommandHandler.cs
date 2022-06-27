using Gelos.DataAccess.Postgres.Common.Exceptions;
using Gelos.DataAccess.Postgres.Entities;
using MediatR;


namespace Gelos.DataAccess.Postgres.Repository.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler
        : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly GelosContext _context;

        public DeleteEmployeeCommandHandler(GelosContext context) =>
            _context = context;

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees
                .FindAsync(new object[] { request.UserId }, cancellationToken);

            if(employee == null || employee.Id != request.UserId)
            {
                throw new NotFoundException(nameof(EmployeeDto), request.UserId);
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
