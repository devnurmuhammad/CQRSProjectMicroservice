using MediatR;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Doctors.Queries
{
    public class GetDoctorByIdQuery : IRequest<Doctor>
    {
        public int Id { get; set; }
    }
}
