using MediatR;
using Microsoft.EntityFrameworkCore;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Employees.Queries;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Employees.Handlers
{
    public class GetEmployeeByIdCommandHandler : IRequestHandler<GetEmployeeCommandById, Employee>
    {
        private readonly IApplicationDbContext? _applicationDbContext;

        public GetEmployeeByIdCommandHandler(IApplicationDbContext? applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Employee> Handle(GetEmployeeCommandById request, CancellationToken cancellationToken)
        {
            Employee result = await _applicationDbContext.Employees.FirstOrDefaultAsync(x => x.Id == request.Id);  
            if (result == null)
            {
                return new Employee();
            }

            return result;
        }
    }
}
