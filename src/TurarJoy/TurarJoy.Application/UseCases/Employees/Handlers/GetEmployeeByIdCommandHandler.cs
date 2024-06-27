using MediatR;
using Microsoft.EntityFrameworkCore;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Employees.Queries;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Employees.Handlers
{
    public class GetEmployeeByIdCommandHandler : IRequestHandler<GetEmployeeCommandById, Employee>
    {
        private readonly ITurarJoyApplicationDbContext _applicationDbContext;

        public GetEmployeeByIdCommandHandler(ITurarJoyApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Employee> Handle(GetEmployeeCommandById request, CancellationToken cancellationToken)
        {
            Employee? result = await _applicationDbContext
                .Employees
                .Include(x => x.Sales)
                .ThenInclude(y => y.Employee)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (result == null)
            {
                return new Employee();
            }

            return result;
        }
    }
}
