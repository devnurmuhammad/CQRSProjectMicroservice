using MediatR;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Employees.Queries
{
    public class GetEmployeeCommandById : IRequest<Employee>
    {
        public int Id { get; set; }
    }
}
