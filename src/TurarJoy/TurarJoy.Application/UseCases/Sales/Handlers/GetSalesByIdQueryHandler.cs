using MediatR;
using Microsoft.EntityFrameworkCore;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Sales.Queries;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Sales.Handlers
{
    public class GetSalesByIdQueryHandler : IRequestHandler<GetSalesByIdQuery, Sale>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetSalesByIdQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Sale> Handle(GetSalesByIdQuery request, CancellationToken cancellationToken)
        {
            Sale? sale = await _applicationDbContext.Sales
                .Include(x => x.Client)
                .ThenInclude(z => z.Sales)
                .ThenInclude(y => y.Employee)
                .ThenInclude(c => c.Sales)
                .ThenInclude(v => v.House)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (sale == null)
            {
                return new Sale();
            }
            return sale;
        }
    }
}
