using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TezYordam.Domain.Entities;

namespace TezYordam.Infrastructure.Persistance.EntitiesConfiguration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Calls)
                .WithOne(x => x.Doctor);
        }
    }
}
