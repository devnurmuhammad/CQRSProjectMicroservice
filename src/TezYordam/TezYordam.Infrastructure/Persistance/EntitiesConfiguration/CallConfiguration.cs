using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TezYordam.Domain.Entities;

namespace TezYordam.Infrastructure.Persistance.EntitiesConfiguration
{
    public class CallConfiguration : IEntityTypeConfiguration<Call>
    {
        public void Configure(EntityTypeBuilder<Call> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Car)
                .WithMany(z => z.Calls);
            builder.HasOne(x => x.Patient)
                .WithMany(z => z.Calls);
            builder.HasOne(x => x.Doctor)
                .WithMany(z => z.Calls);
        }
    }
}
