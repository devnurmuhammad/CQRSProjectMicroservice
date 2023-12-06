using MediatR;
using Microsoft.AspNetCore.Mvc;
using TurarJoy.Application.UseCases.Clients.Commands;
using TurarJoy.Application.UseCases.Clients.Queries;
using TurarJoy.Domain.Entities;
using TurarJoy.Web.ViewModels;

namespace TurarJoy.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllClients()
        {
            var clients = await _mediator.Send(new GetClientCommand());
            return Ok(clients);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateClient(ClientDTO clientdto)
        {
            var client = new CreateClientCommand()
            {
                FirstName = clientdto.FirstName,
                LastName = clientdto.LastName,
                Age = clientdto.Age,
                PassportNumber = clientdto.PassportNumber,
                PhoneNumber = clientdto.PhoneNumber,
            };

            await _mediator.Send(client);

            return Ok("Created");
        }

        [HttpDelete]
        public async ValueTask<ActionResult<bool>> DeleteClient(int id)
        {
            var client = new DeleteClientCommand()
            {
                Id = id
            };

            bool result = await _mediator.Send(client);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<ActionResult<bool>> UpdateClient(UpdateClientCommand updateClientCommand)
        {
            bool result = await _mediator.Send(updateClientCommand);
            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetClientById(int Id)
        {
            
            var result = await _mediator.Send(new GetClientCommandById() { Id = Id});
            return Ok(result);
        }
    }
}
