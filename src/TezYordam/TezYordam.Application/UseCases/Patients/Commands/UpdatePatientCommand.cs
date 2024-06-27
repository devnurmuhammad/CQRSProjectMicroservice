﻿using MediatR;

namespace TezYordam.Application.UseCases.Patients.Commands
{
    public class UpdatePatientCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string? LastName { get; set; }
        public string Phone { get; set; } = default!;
        public string Address { get; set; } = default!;
    }
}
