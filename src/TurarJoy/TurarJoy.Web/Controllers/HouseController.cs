using MediatR;
using Microsoft.AspNetCore.Mvc;
using TurarJoy.Application.UseCases.Houses.Commands;
using TurarJoy.Application.UseCases.Houses.Queries;
using TurarJoy.Web.ViewModels;

namespace TurarJoy.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HouseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllHouse()
        {
            var house = await _mediator.Send(new GetHouseQuery());
            return Ok(house);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateHouse(HouseDTO houseDTO)
        {
            var house = new CreateHouseCommand()
            {
                Name = houseDTO.Name,
                Address = houseDTO.Address,
                CountFlat = houseDTO.CountFlat,
                BuildedAt = DateTime.UtcNow,
            };
            await _mediator.Send(house);

            return Ok("Created");
        }
        [HttpPatch]
        public async ValueTask<ActionResult<bool>> UpdateHouse(UpdateHouseCommand updateHouseCommand)
        {
            bool result = await _mediator.Send(updateHouseCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async ValueTask<ActionResult<bool>> DeleteHouse(int id)
        {
            var house = new DeleteHouseCommand() { Id = id };

            bool result = await _mediator.Send(house);
            return Ok(result);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetHouseById(int id)
        {
            var house = await _mediator.Send(new GetHouseByIdQuery() { Id = id });
            return Ok(house);
        }
    }
}
