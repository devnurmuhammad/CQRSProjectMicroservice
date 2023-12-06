using Microsoft.EntityFrameworkCore;
using TezYordam.Domain.Entities;

namespace TezYordam.Application.Abstractions
{
    public interface ITezYordamApplicationDbContext
    {
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Call> Calls { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
