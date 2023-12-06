using Microsoft.EntityFrameworkCore;
using TurarJoy.Application.Abstractions;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Infrastructure.Persistance;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.Migrate();
    }

    public DbSet<Client> People { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<HouseBuildingCompany> HouseBuildingCompany { get; set; }
    public DbSet<House> Houses { get; set; }
    public DbSet<Sale> Sales { get; set; }

}
