using MediatR;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Houses.Queries
{
    public class GetHouseQuery : IRequest<IList<House>>
    {
    }
}
