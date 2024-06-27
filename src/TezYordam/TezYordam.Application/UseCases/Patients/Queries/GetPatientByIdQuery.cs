using MediatR;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.UseCases.Patients.Queries
{
    public class GetPatientByIdQuery : IRequest<Patient>
    {
        public int Id { get; set; }
    }
}
