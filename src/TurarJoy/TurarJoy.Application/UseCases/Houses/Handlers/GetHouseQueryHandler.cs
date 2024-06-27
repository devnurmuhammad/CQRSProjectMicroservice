using MediatR;
using Microsoft.EntityFrameworkCore;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Houses.Queries;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Houses.Handlers
{
    public class GetHouseQueryHandler : IRequestHandler<GetHouseQuery, IList<House>>
    {
        private readonly ITurarJoyApplicationDbContext _applicationDbContext;

        public GetHouseQueryHandler(ITurarJoyApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IList<House>> Handle(GetHouseQuery request, CancellationToken cancellationToken)
        {
            IList<House> houses = await _applicationDbContext.Houses
                .Include(z => z.Sales)
                .ThenInclude(x => x.Client)
                .ToListAsync();
            return houses;
        }
    }
}
