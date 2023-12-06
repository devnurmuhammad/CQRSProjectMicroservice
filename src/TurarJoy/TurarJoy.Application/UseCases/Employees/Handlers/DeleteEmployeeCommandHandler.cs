using MediatR;
using Microsoft.EntityFrameworkCore;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Employees.Commands;

namespace TurarJoy.Application.UseCases.Employees.Handlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteEmployeeCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var result = await _applicationDbContext.Employees.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null)
            {
                return false;
            }
            _applicationDbContext.Employees.Remove(result);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
    }
}
