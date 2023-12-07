using MediatR;
using Microsoft.EntityFrameworkCore;
using TezYordam.Application.Abstractions;
using TezYordam.Application.UseCases.Patients.Queries;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Patients.Handlers
{
    public class GetByIdPatientHandler : IRequestHandler<GetPatientByIdQuery, Patient>
    {
        private readonly ITezYordamApplicationDbContext _context;

        public GetByIdPatientHandler(ITezYordamApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            Patient? patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (patient == null)
            {
                return new Patient();
            }
            return patient;
        }
    }
}
