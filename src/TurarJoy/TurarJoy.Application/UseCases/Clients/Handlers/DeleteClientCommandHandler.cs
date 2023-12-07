using MediatR;
using Microsoft.EntityFrameworkCore;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Clients.Commands;

namespace TurarJoy.Application.UseCases.Clients.Handlers
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, bool>
    {
        private readonly ITurarJoyApplicationDbContext _applicationDbContext;

        public DeleteClientCommandHandler(ITurarJoyApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _applicationDbContext.Clients.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (client != null)
            {
                _applicationDbContext.Clients.Remove(client);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
