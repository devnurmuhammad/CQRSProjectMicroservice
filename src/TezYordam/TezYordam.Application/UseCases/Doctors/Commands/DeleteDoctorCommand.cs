using MediatR;

namespace TezYordam.Application.UseCases.Doctors.Commands
{
    public class DeleteDoctorCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
