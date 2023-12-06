using MediatR;

namespace TurarJoy.Application.UseCases.Houses.Commands
{
    public class DeleteHouseCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
