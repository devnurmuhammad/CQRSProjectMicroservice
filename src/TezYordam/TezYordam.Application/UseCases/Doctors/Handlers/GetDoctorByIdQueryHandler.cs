using MediatR;
using Microsoft.EntityFrameworkCore;
using TezYordam.Application.Abstractions;
using TezYordam.Application.UseCases.Doctors.Queries;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Doctors.Handlers
{
    internal class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, Doctor>
    {
        private readonly ITezYordamApplicationDbContext _applicationDbContext;

        public GetDoctorByIdQueryHandler(ITezYordamApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Doctor> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            var doctor = await _applicationDbContext.Doctors
                .Include(x => x.Calls)
                .ThenInclude(c => c.Car)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (doctor == null)
            {
                return new Doctor();
            }
            return doctor;
        }
    }
}
