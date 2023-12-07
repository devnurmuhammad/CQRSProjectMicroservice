using MediatR;
using Microsoft.EntityFrameworkCore;
using TezYordam.Application.Abstractions;
using TezYordam.Application.UseCases.Doctors.Queries;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Doctors.Handlers
{
    public class GetDoctorQueryHandler : IRequestHandler<GetDoctorQuery, IList<Doctor>>
    {
        private readonly ITezYordamApplicationDbContext _applicationDbContext;

        public GetDoctorQueryHandler(ITezYordamApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IList<Doctor>> Handle(GetDoctorQuery request, CancellationToken cancellationToken)
        {
            var result = await _applicationDbContext.Doctors
                .Include(x => x.Calls)
                .ThenInclude(y => y.Car)
                .ToListAsync(cancellationToken);
            return result;
        }
    }
}
