using MediatR;

namespace TezYordam.Application.UseCases.Doctors.Commands
{
    public class UpdateDoctorCommand : IRequest<bool>
    { 
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? Position { get; set; }
    }
}
