using MediatR;
using Microsoft.EntityFrameworkCore;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Houses.Commands;

namespace TurarJoy.Application.UseCases.Houses.Handlers
{
    public class UpdateHouseCommandHandler : IRequestHandler<UpdateHouseCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateHouseCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(UpdateHouseCommand request, CancellationToken cancellationToken)
        {
            var house = await _applicationDbContext.Houses.FirstOrDefaultAsync(z => z.Id == z.Id);
            if (house == null)
            {
                return false;
            }
            house.Id = request.Id;
            house.Name = request.Name;
            house.CountFlat = request.CountFlat;

            _applicationDbContext.Houses.Update(house);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
    }
}
