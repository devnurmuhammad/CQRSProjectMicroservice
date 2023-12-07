using MediatR;
using TezYordam.Application.Abstractions;
using TezYordam.Application.UseCases.Doctors.Commands;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Doctors.Handlers
{
    public class CreateDoctorCommandHandler : AsyncRequestHandler<CreateDoctorCommand>
    {
        private readonly ITezYordamApplicationDbContext _applicationDbContext;
        public CreateDoctorCommandHandler(ITezYordamApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        protected override async Task Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = new Doctor()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Position = request.Position,
            };
            await _applicationDbContext.Doctors.AddAsync(doctor);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
