using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Infrastructure.Persistance.EntitiesConfiguration
{
    public class HouseConfigure : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.HasMany(x => x.Sales)
                .WithOne(x => x.House);
        }
    }
}
