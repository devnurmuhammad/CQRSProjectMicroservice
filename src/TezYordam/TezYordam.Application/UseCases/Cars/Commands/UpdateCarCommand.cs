using MediatR;

namespace TezYordam.Application.UseCases.Cars.Commands
{
    public class UpdateCarCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Number { get; set; } = default!;
        public string Model { get; set; } = default!;
    }
}
