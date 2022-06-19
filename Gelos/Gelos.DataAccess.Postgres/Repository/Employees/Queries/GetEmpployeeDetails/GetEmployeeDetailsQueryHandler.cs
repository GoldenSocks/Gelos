using AutoMapper;
using Gelos.DataAccess.Postgres.Common.Exceptions;
using Gelos.DataAccess.Postgres.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Gelos.DataAccess.Postgres.Repository.Employees.Queries.GetEmpployeeDetails
{
    public class GetEmployeeDetailsQueryHandler
        : IRequestHandler<GetEmployeeDetailsQuery, EmployeeDetails>
    {
        private readonly GelosContext _context;
        private readonly IMapper _mapper;

        public GetEmployeeDetailsQueryHandler(GelosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeeDetails> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(employee => employee.Id == request.UserId, cancellationToken);

            if (employee == null || employee.Id != request.UserId)
            {
                throw new NotFoundException(nameof(EmployeeDto), request.UserId);
            }

            return _mapper.Map<EmployeeDetails>(employee);
        }
    }
}
