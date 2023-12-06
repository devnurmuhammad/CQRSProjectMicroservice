using MediatR;
using Microsoft.EntityFrameworkCore;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Houses.Queries;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Houses.Handlers
{
    public class GetHouseQueryHandler : IRequestHandler<GetHouseQuery, IList<House>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetHouseQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IList<House>> Handle(GetHouseQuery request, CancellationToken cancellationToken)
        {
            IList<House> houses = await _applicationDbContext.Houses.ToListAsync();
            return houses;
        }
    }
}
