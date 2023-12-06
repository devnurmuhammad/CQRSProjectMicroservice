using MediatR;
using Microsoft.EntityFrameworkCore;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Clients.Queries;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Clients.Handlers
{
    public class GetClientCommandByIdHandler : IRequestHandler<GetClientCommandById, Client>
    {
        private readonly ITurarJoyApplicationDbContext _applicationDbContext;

        public GetClientCommandByIdHandler(ITurarJoyApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Client> Handle(GetClientCommandById request, CancellationToken cancellationToken)
        {
            var client = await _applicationDbContext.Clients
                .Include(x => x.Sales)
                .ThenInclude(y => y.Client)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (client == null)
            {
                return new Client();
            }

            return client;
        }
    }
}
