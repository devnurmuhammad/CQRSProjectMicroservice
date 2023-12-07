using MediatR;
using Microsoft.AspNetCore.Mvc;
using TezYordam.Application.UseCases.Calls.Commands;
using TezYordam.Application.UseCases.Calls.Queries;
using TezYordam.Domain.Entities;
using TezYordam.Web.ViewModels;

namespace TezYordam.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CallController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CallController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllCall()
        {
            IList<Call> calls = await _mediator.Send(new GetCallQuery());
            return Ok(calls);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateCall(CallDTO callDTO)
        {
            var call = new CreateCallCommand()
            {
                Description = callDTO.Description,
                CalledAt = callDTO.CalledAt,
                ArrivedAt = callDTO.ArrivedAt,
                CarId = callDTO.CarId,
                DoctorId = callDTO.DoctorId,
                PatientId = callDTO.PatientId,
            };
            await _mediator.Send(call);
            return Ok("Created");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetCallById(int id)
        {
            var call = new GetCallById()
            {
                Id = id,
            };
            var result = await _mediator.Send(call);
            return Ok(result);
        }
    }
}
