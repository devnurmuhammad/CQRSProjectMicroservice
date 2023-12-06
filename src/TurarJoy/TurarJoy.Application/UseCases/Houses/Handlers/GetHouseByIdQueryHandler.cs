using MediatR;
using Microsoft.EntityFrameworkCore;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Houses.Queries;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Houses.Handlers
{
    public class GetHouseByIdQueryHandler : IRequestHandler<GetHouseByIdQuery, House>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetHouseByIdQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<House> Handle(GetHouseByIdQuery request, CancellationToken cancellationToken)
        {
            House house = await _applicationDbContext.Houses.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (house == null)
            {
                return new House();
            }
            return house;
        }
    }
}
