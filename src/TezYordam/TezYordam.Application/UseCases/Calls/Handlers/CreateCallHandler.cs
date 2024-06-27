using MediatR;
using TezYordam.Application.Abstractions;
using TezYordam.Application.UseCases.Calls.Commands;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Calls.Handlers
{
    public class CreateCallHandler : AsyncRequestHandler<CreateCallCommand>
    {
        private readonly ITezYordamApplicationDbContext _context;

        public CreateCallHandler(ITezYordamApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(CreateCallCommand request, CancellationToken cancellationToken)
        {
            var call = new Call()
            {
                Description = request.Description,
                ArrivedAt = request.ArrivedAt,
                CalledAt = request.CalledAt,
                DoctorId = request.DoctorId,
                CarId = request.CarId,
                PatientId = request.PatientId,
            };
            await _context.Calls.AddAsync(call);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
