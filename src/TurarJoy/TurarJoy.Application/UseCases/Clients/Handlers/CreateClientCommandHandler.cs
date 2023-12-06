using MediatR;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Clients.Commands;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Clients.Handlers;

public class CreateClientCommandHandler : AsyncRequestHandler<CreateClientCommand>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateClientCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    protected override async Task Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var client = new Client()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Age = request.Age,
            PassportNumber = request.PassportNumber,
            PhoneNumber = request.PhoneNumber,
        };

        await _applicationDbContext.Clients.AddAsync(client);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}
