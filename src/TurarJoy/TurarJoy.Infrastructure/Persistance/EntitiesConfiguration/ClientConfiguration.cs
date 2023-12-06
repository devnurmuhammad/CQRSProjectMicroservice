using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Infrastructure.Persistance.EntitiesConfiguration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasMany(x => x.Sales)
                .WithOne(x => x.Client);
        }
    }
}
