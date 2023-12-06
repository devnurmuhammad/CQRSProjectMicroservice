using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TezYordam.Domain.Entities;

namespace TezYordam.Infrastructure.Persistance.EntitiesConfiguration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Calls)
                .WithOne(x => x.Car);
        }
    }
}
