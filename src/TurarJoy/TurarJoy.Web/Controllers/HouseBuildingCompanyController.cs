using MediatR;
using Microsoft.AspNetCore.Mvc;
using TurarJoy.Application.UseCases.HouseBuildingCompanys.Commands;
using TurarJoy.Application.UseCases.HouseBuildingCompanys.Queries;

namespace TurarJoy.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HouseBuildingCompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HouseBuildingCompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetHouseBuildingCompany()
        {
            var company = await _mediator.Send(new GetHouseCompanyQuery());
            return Ok(company);
        }
        [HttpPatch]
        public async ValueTask<ActionResult<bool>> UpdateHouseBuildingCompany(UpdateCompanyCommand updateCompanyCommand)
        {
            bool result = await _mediator.Send(updateCompanyCommand);
            return Ok(result);
        }
    }
}
