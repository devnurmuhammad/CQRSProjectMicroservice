using MediatR;
using Microsoft.AspNetCore.Mvc;
using TurarJoy.Application.UseCases.Sales.Commands;
using TurarJoy.Application.UseCases.Sales.Queries;
using TurarJoy.Domain.Entities;
using TurarJoy.Web.ViewModels;

namespace TurarJoy.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SaleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllSales()
        {
            IList<Sale> sales = await _mediator.Send(new GetSalesQuery());
            return Ok(sales);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateSale(SaleDTO saleDTO)
        {
            var sale = new CreateSaleCommand()
            {
                Cost = saleDTO.Cost,
                SaledAt = DateTime.UtcNow,
                ClientId = saleDTO.ClientId,
                EmployeeId = saleDTO.EmployeeId,
                HouseId = saleDTO.HouseId,
            };
            await _mediator.Send(sale);
            return Ok("Created");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetSaleById(int id)
        {
            Sale sale = await _mediator.Send(new GetSalesByIdQuery(){ Id = id});
            return Ok(sale);
        }
    }
}
