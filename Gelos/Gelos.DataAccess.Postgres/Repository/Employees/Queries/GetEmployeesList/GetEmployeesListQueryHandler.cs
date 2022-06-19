using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Gelos.DataAccess.Postgres.Repository.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQueryHandler
        : IRequestHandler<GetEmployeesListQuery, EmployeesList>
    {
        private readonly GelosContext _context;
        private readonly IMapper _mapper;

        public GetEmployeesListQueryHandler(GelosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeesList> Handle(GetEmployeesListQuery request,
            CancellationToken cancellation)
        {
            var notesQuery = await _context.Employees
                .Where(employee => employee.Id == request.UserId)
                .ProjectTo<EmployeesLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellation);

            return new EmployeesList { Employees = notesQuery };
        }
    }
}
