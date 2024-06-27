using MediatR;

namespace TurarJoy.Application.UseCases.Employees.Commands
{
    public class CreateEmployeeCommand : IRequest
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Phone { get; set; } = default!;
    }
}
