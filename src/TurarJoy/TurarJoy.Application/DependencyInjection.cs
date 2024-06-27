using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TurarJoy.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            services.AddStackExchangeRedisCache(options =>
            {
                options.InstanceName = "University";
                options.Configuration = "redis,6379";

            });

            return services;
        }
    }
}
