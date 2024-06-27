using MediatR;
using TezYordam.Application.Abstractions;
using TezYordam.Application.UseCases.Cars.Commands;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Cars.Handlers
{
    public class CreateCarCommandHandler : AsyncRequestHandler<CreateCarCommand>
    {
        private readonly ITezYordamApplicationDbContext _context;
        public CreateCarCommandHandler(ITezYordamApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = new Car()
            {
                Name = request.Name,
                Model = request.Model,
                Number = request.Number,
            };

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
