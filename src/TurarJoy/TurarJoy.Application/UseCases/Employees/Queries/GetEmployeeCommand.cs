using MediatR;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Employees.Queries
{
    public class GetEmployeeCommand : IRequest<IList<Employee>>
    {

    }
}
