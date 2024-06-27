using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using TurarJoy.Application.Abstractions;
using TurarJoy.Domain.Entities;
using TurarJoy.Infrastructure.Persistance.EntitiesConfiguration;

namespace TurarJoy.Infrastructure.Persistance;

public class ApplicationDbContext : DbContext, ITurarJoyApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
        try
        {
            if (databaseCreator is null)
            {
                throw new Exception("Database Not Found!");
            }

            if (!databaseCreator.CanConnect())
                databaseCreator.CreateAsync();

            if (!databaseCreator.HasTables())
                databaseCreator.CreateTablesAsync();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new HouseBuildingCompanyConfiguration());
    }
    public DbSet<Client> People { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<HouseBuildingCompany> HouseBuildingCompany { get; set; }
    public DbSet<House> Houses { get; set; }
    public DbSet<Sale> Sales { get; set; }
}
