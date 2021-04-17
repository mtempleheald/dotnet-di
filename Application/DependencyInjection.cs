using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetDI.Application 
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ClientServiceMappingOptions>(configuration.GetSection(ClientServiceMappingOptions.ClientServiceMappings));
            
            return services;
        }
    }
}