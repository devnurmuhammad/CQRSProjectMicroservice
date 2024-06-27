using MediatR;
using Microsoft.AspNetCore.Mvc;
using TezYordam.Application.UseCases.Hospitals.Commands;
using TezYordam.Application.UseCases.Hospitals.Queries;

namespace TezYordam.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HospitalController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllHospital()
        {
            var result = await _mediator.Send(new GetHospitalQuery());
            return Ok(result);
        }
        [HttpPatch]
        public async ValueTask<ActionResult<bool>> UpdateHospital(UpdateHospitalCommand updateHospital)
        {
            bool result = await _mediator.Send(updateHospital);
            return Ok(result);
        }
    }
}
