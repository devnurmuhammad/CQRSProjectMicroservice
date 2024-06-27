using MediatR;

namespace TezYordam.Application.UseCases.Cars.Commands
{
    public class CreateCarCommand : IRequest
    {
        public string Name { get; set; } = default!;
        public string Number { get; set; } = default!;
        public string Model { get; set; } = default!;
    }
}
