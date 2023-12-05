using Microsoft.EntityFrameworkCore;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Application.Abstractions;

public interface IApplicationDbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<HouseBuildingCompany> HouseBuildingCompany { get; set; }
    public DbSet<House> Houses { get; set; }
    public DbSet<Sale> Sales { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
