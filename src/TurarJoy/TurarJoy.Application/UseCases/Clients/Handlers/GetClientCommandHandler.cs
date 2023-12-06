using MediatR;
using Microsoft.EntityFrameworkCore;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Clients.Queries;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Clients.Handlers
{
    public class GetClientCommandHandler : IRequestHandler<GetClientCommand, IList<Client>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetClientCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IList<Client>> Handle(GetClientCommand request, CancellationToken cancellationToken)
        {
            var result = await _applicationDbContext.Clients.ToListAsync();
            return result;
        }
    }
}
