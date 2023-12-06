using MediatR;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Houses.Queries
{
    public class GetHouseByIdQuery : IRequest<House>
    {
        public int Id { get; set; }
    }
}
