using MediatR;
using Microsoft.EntityFrameworkCore;
using TezYordam.Application.Abstractions;
using TezYordam.Application.UseCases.Cars.Queries;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Cars.Handlers
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, Car>
    {
        private readonly ITezYordamApplicationDbContext _context;

        public GetCarByIdQueryHandler(ITezYordamApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Car> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            Car? car = await _context.Cars
                .Include(c => c.Calls)
                .ThenInclude(x => x.Doctor)
                .FirstOrDefaultAsync(z => z.Id == request.Id);

            if (car == null)
            {
                return new Car();
            }
            return car;
        }
    }
}
