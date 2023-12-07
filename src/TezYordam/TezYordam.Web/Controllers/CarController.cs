using MediatR;
using Microsoft.AspNetCore.Mvc;
using TezYordam.Application.UseCases.Cars.Commands;
using TezYordam.Application.UseCases.Cars.Queries;
using TezYordam.Domain.Entities;
using TezYordam.Web.ViewModels;

namespace TezYordam.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllCar()
        {
            IList<Car> cars = await _mediator.Send(new GetCarQuery());
            return Ok(cars);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetCarById(int id)
        {
            Car car = await _mediator.Send(new GetCarByIdQuery() { Id = id });
            return Ok(car);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateCar(CarDTO carDTO)
        {
            var car = new CreateCarCommand()
            {
                Name = carDTO.Name,
                Model = carDTO.Model,
                Number = carDTO.Number,
            };
            await _mediator.Send(car);
            return Ok("Created");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateCar(UpdateCarCommand updateCar)
        {
            bool result = await _mediator.Send(updateCar);
            return Ok(result);
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCar(int id)
        {
            bool result = await _mediator.Send(new DeleteCarCommand() { Id = id});
            return Ok(result);
        }
    }
}
