using MediatR;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Sales.Commands;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Sales.Handlers
{
    public class CreateSaleCommandHandler : AsyncRequestHandler<CreateSaleCommand>
    {
        private readonly ITurarJoyApplicationDbContext _applicationDbContext;

        public CreateSaleCommandHandler(ITurarJoyApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        protected override async Task Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            Sale sale = new Sale()
            {
                Cost = request.Cost,
                SaledAt = DateTime.UtcNow,
                ClientId = request.ClientId,
                EmployeeId = request.EmployeeId,
                HouseId = request.HouseId,
            };

            await _applicationDbContext.Sales.AddAsync(sale);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
