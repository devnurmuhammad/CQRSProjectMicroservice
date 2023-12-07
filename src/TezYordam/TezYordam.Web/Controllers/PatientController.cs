using MediatR;
using Microsoft.AspNetCore.Mvc;
using TezYordam.Application.UseCases.Patients.Commands;
using TezYordam.Application.UseCases.Patients.Queries;
using TezYordam.Domain.Entities;
using TezYordam.Web.ViewModels;

namespace TezYordam.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllPatient()
        {
            IList<Patient> patients = await _mediator.Send(new GetPatientQuery());
            return Ok(patients);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreatePatient(PatientDTO patientDTO)
        {
            var patient = new CreatePatientCommand()
            {
                FirstName = patientDTO.FirstName,
                LastName = patientDTO.LastName,
                Address = patientDTO.Address,
                Phone = patientDTO.Phone,
            };
            await _mediator.Send(patient);
            return Ok("Created");
        }
        [HttpPut]
        public async ValueTask<ActionResult<bool>> UpdatePatient(UpdatePatientCommand command)
        {
            bool result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetPatientById(int id)
        {
            var result = await _mediator.Send(new GetPatientByIdQuery() { Id = id });
            return Ok(result);
        }
    }
}
