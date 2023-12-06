using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TezYordam.Domain.Entities;

namespace TezYordam.Infrastructure.Persistance.EntitiesConfiguration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Calls)
                .WithOne(x => x.Patient);
        }
    }
}
