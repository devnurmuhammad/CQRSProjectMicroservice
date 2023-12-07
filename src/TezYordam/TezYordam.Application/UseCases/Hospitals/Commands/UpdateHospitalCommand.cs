using MediatR;

namespace TezYordam.Application.UseCases.Hospitals.Commands
{
    public class UpdateHospitalCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string? Email { get; set; }
        public string Address { get; set; } = default!;
    }
}
