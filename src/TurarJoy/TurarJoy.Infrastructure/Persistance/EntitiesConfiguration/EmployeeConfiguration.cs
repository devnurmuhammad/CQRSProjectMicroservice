using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TurarJoy.Domain.Entities;

namespace TurarJoy.Infrastructure.Persistance.EntitiesConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasMany(x => x.Sales)
                .WithOne(x => x.Employee);
        }
    }
}
