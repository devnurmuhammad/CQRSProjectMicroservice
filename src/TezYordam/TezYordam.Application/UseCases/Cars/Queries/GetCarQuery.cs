using MediatR;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Cars.Queries
{
    public class GetCarQuery : IRequest<IList<Car>>
    {
    }
}
