using Microsoft.EntityFrameworkCore;
using TezYordam.Application.Abstractions;
using TezYordam.Domain.Entities;

namespace TezYordam.Infrastructure.Persistance;

public class ApplicationDbContext : DbContext, ITezYordamApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Call> Calls { get; set; }
}
