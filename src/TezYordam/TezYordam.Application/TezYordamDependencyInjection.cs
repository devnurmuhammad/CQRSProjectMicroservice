using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TezYordam.Application
{
    public static class TezYordamDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
