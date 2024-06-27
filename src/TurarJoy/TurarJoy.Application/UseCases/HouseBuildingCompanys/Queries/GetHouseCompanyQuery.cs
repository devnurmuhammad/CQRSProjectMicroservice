using MediatR;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.HouseBuildingCompanys.Queries
{
    public class GetHouseCompanyQuery : IRequest<IList<HouseBuildingCompany>>
    {
    }
}
