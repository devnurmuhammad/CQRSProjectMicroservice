using MediatR;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Calls.Queries
{
    public class GetCallById : IRequest<Call>
    {
        public int Id { get; set; }
    }
}
