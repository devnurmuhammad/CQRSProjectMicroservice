using MediatR;
using TezYordam.Application.Abstractions;
using TezYordam.Application.UseCases.Patients.Commands;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Patients.Handlers
{
    public class CreatePatienHandler : AsyncRequestHandler<CreatePatientCommand>
    {
        private readonly ITezYordamApplicationDbContext _context;

        public CreatePatienHandler(ITezYordamApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            Patient patient = new Patient()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                Phone = request.Phone,
            };
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
