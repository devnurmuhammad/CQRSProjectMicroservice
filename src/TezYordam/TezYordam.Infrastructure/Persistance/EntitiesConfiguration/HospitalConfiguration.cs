using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TezYordam.Domain.Entities;

namespace TezYordam.Infrastructure.Persistance.EntitiesConfiguration
{
    public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(new Hospital
            {
                Id = 1,
                Name = "SebzorTTB",
                Address = "Sebzor tumani",
                Phone = "+998713254565",
                Email = "sebzorttb@gmail.com"
            });
        }
    }
}
