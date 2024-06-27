using MediatR;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Sales.Queries
{
    public class GetSalesQuery : IRequest<IList<Sale>>
    {
    }
}
