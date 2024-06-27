﻿using MediatR;

namespace TurarJoy.Application.UseCases.Clients.Commands
{
    public class CreateClientCommand : IRequest
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string PassportNumber { get; set; } = default!;
        public int Age { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
