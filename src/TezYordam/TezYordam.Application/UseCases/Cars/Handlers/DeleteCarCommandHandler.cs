using MediatR;
using Microsoft.EntityFrameworkCore;
using TezYordam.Application.Abstractions;
using TezYordam.Application.UseCases.Cars.Commands;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Cars.Handlers
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, bool>
    {
        private readonly ITezYordamApplicationDbContext _context;

        public DeleteCarCommandHandler(ITezYordamApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            Car? car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (car == null)
            {
                return false;
            }
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync(cancellationToken);
            
            return true;
        }
    }
}
