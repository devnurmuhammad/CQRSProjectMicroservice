using MediatR;
using Microsoft.EntityFrameworkCore;
using TezYordam.Application.Abstractions;
using TezYordam.Application.UseCases.Cars.Commands;

namespace TezYordam.Application.UseCases.Cars.Handlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, bool>
    {
        private readonly ITezYordamApplicationDbContext _context;

        public UpdateCarCommandHandler(ITezYordamApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (car == null)
            {
                return false;
            }
            car.Name = request.Name;
            car.Model = request.Model;
            car.Number = request.Number;
            _context.Cars.Update(car);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
