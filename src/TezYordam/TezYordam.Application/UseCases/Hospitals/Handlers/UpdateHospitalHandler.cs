using MediatR;
using Microsoft.EntityFrameworkCore;
using TezYordam.Application.Abstractions;
using TezYordam.Application.UseCases.Hospitals.Commands;

namespace TezYordam.Application.UseCases.Hospitals.Handlers
{
    public class UpdateHospitalHandler : IRequestHandler<UpdateHospitalCommand, bool>
    {
        private readonly ITezYordamApplicationDbContext _context;
        public UpdateHospitalHandler(ITezYordamApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateHospitalCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.Hospitals.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null)
            {
                return false;
            }
            result.Phone = request.Phone; 
            result.Name = request.Name;
            result.Email = request.Email;
            result.Address = request.Address;
            _context.Hospitals.Update(result);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
