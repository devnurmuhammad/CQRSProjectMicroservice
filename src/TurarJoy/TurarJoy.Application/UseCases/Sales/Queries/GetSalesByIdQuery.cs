using MediatR;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Sales.Queries
{
    public class GetSalesByIdQuery : IRequest<Sale>
    {
        public int Id { get; set; }
    }
}
