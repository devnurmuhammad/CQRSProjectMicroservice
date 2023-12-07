using MediatR;
using Microsoft.EntityFrameworkCore;
using TezYordam.Application.Abstractions;
using TezYordam.Application.UseCases.Doctors.Commands;

namespace TezYordam.Application.UseCases.Doctors.Handlers
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, bool>
    {
        private readonly ITezYordamApplicationDbContext _applicationDbContext;
        public UpdateDoctorCommandHandler(ITezYordamApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<bool> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _applicationDbContext.Doctors.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (doctor == null)
            {
                return false;
            }
            doctor.FirstName = request.FirstName;
            doctor.LastName = request.LastName;
            doctor.Position = request.Position;

            _applicationDbContext.Doctors.Update(doctor);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
