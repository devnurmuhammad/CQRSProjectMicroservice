using MediatR;
using Microsoft.EntityFrameworkCore;
using TezYordam.Application.Abstractions;
using TezYordam.Application.UseCases.Cars.Queries;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Cars.Handlers
{
    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, IList<Car>>
    {
        private readonly ITezYordamApplicationDbContext _context;

        public GetCarQueryHandler(ITezYordamApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Car>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            IList<Car> cars = await _context.Cars
                .Include(x => x.Calls)
                .ThenInclude(c => c.Doctor)
                .ToListAsync(cancellationToken);
            return cars;
        }
    }
}
