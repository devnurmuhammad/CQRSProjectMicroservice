using MediatR;
using Microsoft.AspNetCore.Mvc;
using TezYordam.Application.UseCases.Doctors.Commands;
using TezYordam.Application.UseCases.Doctors.Queries;
using TezYordam.Domain.Entities;
using TezYordam.Web.ViewModels;

namespace TezYordam.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllDoctors()
        {
            var doctors = await _mediator.Send(new GetDoctorQuery());
            return Ok(doctors);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateDoctor(DoctorDTO doctorDTO)
        {
            var doctor = new CreateDoctorCommand()
            {
                FirstName = doctorDTO.FirstName,
                LastName = doctorDTO.LastName,
                Position = doctorDTO.Position,
            };
            await _mediator.Send(doctor);
            return Ok("Created");
        }
        [HttpPatch]
        public async ValueTask<ActionResult<bool>> UpdateDoctor(UpdateDoctorCommand updateDoctor)
        {
            bool result = await _mediator.Send(updateDoctor);
            return Ok(result);
        }
        [HttpDelete]
        public async ValueTask<ActionResult<bool>> DeleteDoctor(int id)
        {
            var result = new DeleteDoctorCommand()
            {
                Id = id
            };
            bool doctor = await _mediator.Send(result);
            return Ok(doctor);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetDoctorById(int id)
        {
            Doctor doctor = await _mediator.Send(new GetDoctorByIdQuery() { Id = id });
            return Ok(doctor);
        }
    }
}
