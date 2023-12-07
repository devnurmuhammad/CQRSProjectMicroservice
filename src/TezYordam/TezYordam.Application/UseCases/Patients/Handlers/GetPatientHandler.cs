using MediatR;
using Microsoft.EntityFrameworkCore;
using TezYordam.Application.Abstractions;
using TezYordam.Application.UseCases.Patients.Queries;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Patients.Handlers
{
    public class GetPatientHandler : IRequestHandler<GetPatientQuery, IList<Patient>>
    {
        private readonly ITezYordamApplicationDbContext _context;

        public GetPatientHandler(ITezYordamApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Patient>> Handle(GetPatientQuery request, CancellationToken cancellationToken)
        {
            IList<Patient> patients = await _context.Patients
                .Include(x => x.Calls)
                .ThenInclude(z => z.Doctor)
                .ThenInclude(c => c.Calls)
                .ThenInclude(v => v.Car)
                .ToListAsync(cancellationToken);
            return patients;
        }
    }
}
