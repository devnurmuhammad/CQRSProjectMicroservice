using MediatR;
using Microsoft.EntityFrameworkCore;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Employees.Commands;

namespace TurarJoy.Application.UseCases.Employees.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly ITurarJoyApplicationDbContext _applicationDbContext;

        public UpdateEmployeeCommandHandler(ITurarJoyApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var result = await _applicationDbContext.Employees.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null)
            {
                return false;
            }

            result.FirstName = request.FirstName;
            result.LastName = request.LastName;
            result.Phone = request.Phone;

            _applicationDbContext.Employees.Update(result);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
