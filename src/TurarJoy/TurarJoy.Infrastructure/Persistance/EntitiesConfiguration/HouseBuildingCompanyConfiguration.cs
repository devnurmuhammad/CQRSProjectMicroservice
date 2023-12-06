using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Infrastructure.Persistance.EntitiesConfiguration
{
    public class HouseBuildingCompanyConfiguration : IEntityTypeConfiguration<HouseBuildingCompany>
    {
        public void Configure(EntityTypeBuilder<HouseBuildingCompany> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(new HouseBuildingCompany
            {
                Id = 1,
                Name = "Murad Buildings",
                Address = "Tashkent",
                Email = "MuradBuildings2023@gmail.com",
                PhoneNumber = "+998714522145"
            });
        }
    }
}
