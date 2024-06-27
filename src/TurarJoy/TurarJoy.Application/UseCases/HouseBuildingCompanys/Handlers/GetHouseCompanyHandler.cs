using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.HouseBuildingCompanys.Queries;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.HouseBuildingCompanys.Handlers
{
    public class GetHouseCompanyHandler : IRequestHandler<GetHouseCompanyQuery, IList<HouseBuildingCompany>>
    {
        private readonly ITurarJoyApplicationDbContext _applicationDbContext;
        private readonly IDistributedCache _cache;


        public GetHouseCompanyHandler(ITurarJoyApplicationDbContext applicationDbContext, IDistributedCache cache)
        {
            _applicationDbContext = applicationDbContext;
            _cache = cache;
        }

        public async Task<IList<HouseBuildingCompany>> Handle(GetHouseCompanyQuery request, CancellationToken cancellationToken)
        {
            string? response = _cache.GetString("GetAllHouses");

            if (response != null)
            {
                var cacheHouses = JsonConvert.DeserializeObject<IList<HouseBuildingCompany>>(response);

                return cacheHouses;
            }

            var company = await _applicationDbContext.HouseBuildingCompany.ToListAsync(cancellationToken);
            
            _cache.SetString("GetAllHouses", JsonConvert.SerializeObject(company));
            return company;
        }
    }
}

