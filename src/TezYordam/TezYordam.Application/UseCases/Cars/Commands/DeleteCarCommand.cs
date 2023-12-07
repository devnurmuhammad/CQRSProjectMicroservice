using MediatR;

namespace TezYordam.Application.UseCases.Cars.Commands
{
    public class DeleteCarCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
