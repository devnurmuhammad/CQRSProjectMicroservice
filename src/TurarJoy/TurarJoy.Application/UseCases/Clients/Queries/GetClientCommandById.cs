using MediatR;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Clients.Queries
{
    public class GetClientCommandById : IRequest<Client>
    {
        public int Id { get; set; }
    }
}
