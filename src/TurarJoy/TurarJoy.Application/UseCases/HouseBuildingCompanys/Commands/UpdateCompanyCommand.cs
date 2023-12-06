using MediatR;

namespace TurarJoy.Application.UseCases.HouseBuildingCompanys.Commands
{
    public class UpdateCompanyCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
