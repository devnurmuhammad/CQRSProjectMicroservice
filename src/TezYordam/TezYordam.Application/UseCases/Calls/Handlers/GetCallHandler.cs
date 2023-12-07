using MediatR;
using Microsoft.EntityFrameworkCore;
using TezYordam.Application.Abstractions;
using TezYordam.Application.UseCases.Calls.Queries;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Calls.Handlers
{
    public class GetCallHandler : IRequestHandler<GetCallQuery, IList<Call>>
    {
        private readonly ITezYordamApplicationDbContext _context;

        public GetCallHandler(ITezYordamApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Call>> Handle(GetCallQuery request, CancellationToken cancellationToken)
        {
            IList<Call> calls = await _context.Calls
                .Include(x => x.Car)
                .ThenInclude(z => z.Calls)
                .ThenInclude(c => c.Doctor)
                .ThenInclude(v => v.Calls)
                .ThenInclude(b => b.Patient)
                .ToListAsync(cancellationToken);
            return calls;
        }
    }
}
