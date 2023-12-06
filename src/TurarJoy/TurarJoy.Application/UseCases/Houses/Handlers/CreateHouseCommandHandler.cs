using MediatR;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Houses.Commands;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Houses.Handlers
{
    public class CreateHouseCommandHandler : AsyncRequestHandler<CreateHouseCommand>
    {
        private readonly ITurarJoyApplicationDbContext _applicationDbContext;

        public CreateHouseCommandHandler(ITurarJoyApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        protected override async Task Handle(CreateHouseCommand request, CancellationToken cancellationToken)
        {
            var houese = new House()
            {
                Name = request.Name,
                Address = request.Address,
                CountFlat = request.CountFlat,
                BuildedAt = DateTime.UtcNow,
            };
            await _applicationDbContext.Houses.AddAsync(houese);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
