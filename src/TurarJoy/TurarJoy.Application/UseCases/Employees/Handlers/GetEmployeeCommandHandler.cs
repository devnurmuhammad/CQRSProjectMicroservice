using MediatR;
using Microsoft.EntityFrameworkCore;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Employees.Queries;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Employees.Handlers
{
    public class GetEmployeeCommandHandler : IRequestHandler<GetEmployeeCommand, IList<Employee>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetEmployeeCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IList<Employee>> Handle(GetEmployeeCommand request, CancellationToken cancellationToken)
        {
            IList<Employee> employees = await _applicationDbContext
                .Employees
                .Include(x => x.Sales)
                .ThenInclude(y => y.Client)
                .ToListAsync(cancellationToken);
            return employees;
        }
    }
}
