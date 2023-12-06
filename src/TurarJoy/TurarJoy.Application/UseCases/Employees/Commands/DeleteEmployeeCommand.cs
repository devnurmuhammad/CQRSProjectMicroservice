using MediatR;

namespace TurarJoy.Application.UseCases.Employees.Commands
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
