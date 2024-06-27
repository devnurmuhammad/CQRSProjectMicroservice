using MediatR;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Cars.Queries
{
    public class GetCarByIdQuery : IRequest<Car>
    {
        public int Id { get; set; }
    }
}
