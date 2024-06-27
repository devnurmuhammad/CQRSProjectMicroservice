using MediatR;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Doctors.Queries
{
    public class GetDoctorQuery : IRequest<IList<Doctor>>
    {
    }
}
