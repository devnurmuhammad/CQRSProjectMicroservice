using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TezYordam.Application.Abstractions;
using TezYordam.Infrastructure.Persistance;

namespace TezYordam.Infrastructure;

public static class TezYordamInDependencyInjection
{
    public static IServiceCollection TYInfAddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ITezYordamApplicationDbContext, ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ConnectionStringDoc"));
        });

        return services;
    }
}
