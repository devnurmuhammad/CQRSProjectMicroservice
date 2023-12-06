using MediatR;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Clients.Queries
{
    public class GetClientCommand : IRequest<IList<Client>>
    {

    }
}
