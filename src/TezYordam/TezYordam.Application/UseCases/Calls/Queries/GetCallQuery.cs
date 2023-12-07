using MediatR;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Calls.Queries
{
    public class GetCallQuery : IRequest<IList<Call>>
    {
    }
}
