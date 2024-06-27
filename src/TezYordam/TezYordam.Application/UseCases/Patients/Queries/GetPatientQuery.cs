using MediatR;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Patients.Queries
{
    public class GetPatientQuery : IRequest<IList<Patient>>
    {
    }
}
