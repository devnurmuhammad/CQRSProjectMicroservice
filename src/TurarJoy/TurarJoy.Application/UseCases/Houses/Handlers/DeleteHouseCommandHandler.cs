using MediatR;
using Microsoft.EntityFrameworkCore;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Houses.Commands;

namespace TurarJoy.Application.UseCases.Houses.Handlers
{
    public class DeleteHouseCommandHandler : IRequestHandler<DeleteHouseCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteHouseCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(DeleteHouseCommand request, CancellationToken cancellationToken)
        {
            var result = await _applicationDbContext.Houses.FirstOrDefaultAsync(z => z.Id == request.Id);
            if (result == null)
            {
                return false;
            }
            _applicationDbContext.Houses.Remove(result);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
