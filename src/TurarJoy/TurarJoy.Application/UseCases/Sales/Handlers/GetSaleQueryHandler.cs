using MediatR;
using Microsoft.EntityFrameworkCore;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Sales.Queries;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Sales.Handlers
{
    public class GetSaleQueryHandler : IRequestHandler<GetSalesQuery, IList<Sale>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetSaleQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IList<Sale>> Handle(GetSalesQuery request, CancellationToken cancellationToken)
        {
            IList<Sale> sales = await _applicationDbContext.Sales
                .Include(x => x.Client)
                .ThenInclude(z => z.Sales)
                .ThenInclude(y => y.Employee)
                .ThenInclude(c => c.Sales)
                .ThenInclude(v => v.House)
                .ToListAsync(cancellationToken);
            return sales;
        }
    }
}
