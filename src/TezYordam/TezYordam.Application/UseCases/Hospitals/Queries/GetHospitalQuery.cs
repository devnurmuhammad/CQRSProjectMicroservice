using MediatR;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Hospitals.Queries
{
    public class GetHospitalQuery : IRequest<IList<Hospital>>
    {
    }
}
