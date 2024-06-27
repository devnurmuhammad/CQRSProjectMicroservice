using MediatR;
using Microsoft.AspNetCore.Mvc;
using TurarJoy.Application.UseCases.Employees.Commands;
using TurarJoy.Application.UseCases.Employees.Queries;
using TurarJoy.Web.ViewModels;

namespace TurarJoy.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllEmployee()
        {
            var employees = await _mediator.Send(new GetEmployeeCommand());
            return Ok(employees);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateEmployee(EmployeeDTO employeeDTO)
        {
            var employee = new CreateEmployeeCommand()
            {
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                Phone = employeeDTO.Phone,
            };
            await _mediator.Send(employee);

            return Ok("Created");
        }
        [HttpDelete]
        public async ValueTask<ActionResult<bool>> DeleteEmployee(int id)
        {
            var employee = new DeleteEmployeeCommand()
            {
                Id = id
            };
            bool result = await _mediator.Send(employee);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<ActionResult<bool>> UpdateEmployee(UpdateEmployeeCommand updateEmployeeCommand)
        {
            bool result = await _mediator.Send(updateEmployeeCommand);
            return Ok(result);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetEmployeeById(int id)
        {
            var result = await _mediator.Send(new GetEmployeeCommandById() { Id = id });
            return Ok(result);
        }
    }
}
