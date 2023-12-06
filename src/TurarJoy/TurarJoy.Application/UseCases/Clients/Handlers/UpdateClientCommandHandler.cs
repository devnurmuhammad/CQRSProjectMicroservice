using MediatR;
using Microsoft.EntityFrameworkCore;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Clients.Commands;

namespace TurarJoy.Application.UseCases.Clients.Handlers
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateClientCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var result = await _applicationDbContext.Clients.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null)
            {
                return false;
            }
            else
            {

                result.FirstName = request.FirstName;
                result.LastName = request.LastName;
                result.Age = request.Age;
                result.PassportNumber = request.PassportNumber;
                result.PhoneNumber = request.PhoneNumber;


                _applicationDbContext.Clients.Update(result);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
    }
}
