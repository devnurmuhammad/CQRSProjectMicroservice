using MediatR;
using Microsoft.EntityFrameworkCore;
using TezYordam.Application.Abstractions;
using TezYordam.Application.UseCases.Patients.Commands;

namespace TezYordam.Application.UseCases.Patients.Handlers
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, bool>
    {
        private readonly ITezYordamApplicationDbContext _context;

        public UpdatePatientHandler(ITezYordamApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(z => z.Id == request.Id);
            if (patient == null)
            {
                return false;
            }
            patient.FirstName = request.FirstName;
            patient.LastName = request.LastName;
            patient.Address = request.Address;
            patient.Phone = request.Phone;

            _context.Patients.Update(patient);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
