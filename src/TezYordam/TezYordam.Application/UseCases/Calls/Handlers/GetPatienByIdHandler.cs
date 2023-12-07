using MediatR;
using Microsoft.EntityFrameworkCore;
using TezYordam.Application.Abstractions;
using TezYordam.Application.UseCases.Calls.Queries;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Calls.Handlers
{
    public class GetPatienByIdHandler : IRequestHandler<GetCallById, Call>
    {
        private readonly ITezYordamApplicationDbContext _context;

        public GetPatienByIdHandler(ITezYordamApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Call> Handle(GetCallById request, CancellationToken cancellationToken)
        {
            var result = await _context.Calls
                .Include(z => z.Car)
                .ThenInclude(v => v.Calls)
                .ThenInclude(x => x.Doctor)
                .ThenInclude(v => v.Calls)
                .ThenInclude(b => b.Patient)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null)
            {
                return new Call();
            }
            return result;
        }
    }
}
