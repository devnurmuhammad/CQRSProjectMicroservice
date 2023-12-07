using MediatR;
using Microsoft.EntityFrameworkCore;
using TezYordam.Application.Abstractions;
using TezYordam.Application.UseCases.Doctors.Commands;

namespace TezYordam.Application.UseCases.Doctors.Handlers
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, bool>
    {
        private readonly ITezYordamApplicationDbContext _context;

        public DeleteDoctorCommandHandler(ITezYordamApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (doctor == null)
            {
                return false;
            }
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
