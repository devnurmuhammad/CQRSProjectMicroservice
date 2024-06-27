using MediatR;

namespace TurarJoy.Application.UseCases.Houses.Commands
{
    public class UpdateHouseCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public int CountFlat { get; set; }
    }
}
