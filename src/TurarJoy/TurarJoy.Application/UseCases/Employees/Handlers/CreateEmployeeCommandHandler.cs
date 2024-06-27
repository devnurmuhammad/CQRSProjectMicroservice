using MediatR;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Employees.Commands;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Employees.Handlers;

public class CreateEmployeeCommandHandler : AsyncRequestHandler<CreateEmployeeCommand>
{
    private readonly ITurarJoyApplicationDbContext _applicationDbContext;

    public CreateEmployeeCommandHandler(ITurarJoyApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    protected override async Task Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Employee()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Phone = request.Phone,
        };
        await _applicationDbContext.Employees.AddAsync(employee);
        await _applicationDbContext.SaveChangesAsync();
    }
}
