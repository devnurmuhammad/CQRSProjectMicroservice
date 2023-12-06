using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Infrastructure.Persistance.EntitiesConfiguration
{
    public class HouseConfiguration
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasIndex(x => x.HouseId)
                .IsUnique();
        }
    }
}

