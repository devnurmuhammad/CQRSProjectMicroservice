﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using TurarJoy.Application.Abstractions;
using TurarJoy.Application.UseCases.Clients.Queries;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.UseCases.Clients.Handlers
{
    public class GetClientCommandHandler : IRequestHandler<GetClientCommand, IList<Client>>
    {
        private readonly ITurarJoyApplicationDbContext _applicationDbContext;

        public GetClientCommandHandler(ITurarJoyApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IList<Client>> Handle(GetClientCommand request, CancellationToken cancellationToken)
        {
            var result = await _applicationDbContext.Clients
                .Include(x => x.Sales)
                .ThenInclude(y => y.Employee)
                .ToListAsync();
            return result;
        }
    }
}
