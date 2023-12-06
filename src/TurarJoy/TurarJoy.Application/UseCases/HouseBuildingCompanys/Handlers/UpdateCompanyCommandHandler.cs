using MediatR;
using Microsoft.EntityFrameworkCore;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.HouseBuildingCompanys.Commands;

namespace TurarJoy.Application.UseCases.HouseBuildingCompanys.Handlers
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateCompanyCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _applicationDbContext.HouseBuildingCompany.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (company == null)
            {
                return false;
            }

            company.Name = request.Name;
            company.PhoneNumber = request.PhoneNumber;
            company.Address = request.Address;

            _applicationDbContext.HouseBuildingCompany.Update(company);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
    }
}