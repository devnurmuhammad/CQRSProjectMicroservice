using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Infrastructure.Persistance.EntitiesConfiguration
{
    public class SaleConfiguration
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasIndex(x => x.HouseId)
                .IsUnique();
            builder.HasOne(x => x.House)
                .WithMany(z => z.Sales);
            builder.HasOne(x => x.Client)
                .WithMany(z => z.Sales);
            builder.HasOne(x => x.Employee)
                .WithMany(z => z.Sales);
        }
    }
}

