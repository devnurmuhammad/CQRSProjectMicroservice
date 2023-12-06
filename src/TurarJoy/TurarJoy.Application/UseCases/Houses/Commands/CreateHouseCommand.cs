using MediatR;

namespace TurarJoy.Application.UseCases.Houses.Commands
{
    public class CreateHouseCommand : IRequest
    {
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public int CountFlat { get; set; }
        public DateTime BuildedAt { get; set; } 
    }
}
