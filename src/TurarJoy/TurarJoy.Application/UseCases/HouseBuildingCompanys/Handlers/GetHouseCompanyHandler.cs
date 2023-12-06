using MediatR;
using Microsoft.EntityFrameworkCore;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.HouseBuildingCompanys.Queries;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.HouseBuildingCompanys.Handlers
{
    public class GetHouseCompanyHandler : IRequestHandler<GetHouseCompanyQuery, IList<HouseBuildingCompany>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetHouseCompanyHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IList<HouseBuildingCompany>> Handle(GetHouseCompanyQuery request, CancellationToken cancellationToken)
        {
            var company = await _applicationDbContext.HouseBuildingCompany.ToListAsync(cancellationToken);
            return company;
        }
    }
}
