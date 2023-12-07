using MediatR;
using Microsoft.EntityFrameworkCore;
using TezYordam.Application.Abstractions;
using TezYordam.Application.UseCases.Hospitals.Queries;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Hospitals.Handlers
{
    public class GetHospitalHandler : IRequestHandler<GetHospitalQuery, IList<Hospital>>
    {
        private readonly ITezYordamApplicationDbContext _context;

        public GetHospitalHandler(ITezYordamApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Hospital>> Handle(GetHospitalQuery request, CancellationToken cancellationToken)
        {
            var hospital = await _context.Hospitals.ToListAsync(cancellationToken);
            if (hospital == null)
            {
                return new List<Hospital>();
            }
            return hospital;
        }
    }
}
