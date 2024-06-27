using MediatR;

namespace TezYordam.Application.UseCases.Doctors.Commands
{
    public class CreateDoctorCommand : IRequest
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? Position { get; set; }
    }
}
