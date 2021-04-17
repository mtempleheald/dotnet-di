using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DotnetDI.Infrastructure.Services.ExampleService;

namespace DotnetDI.Infrastructure 
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {            
            services.AddTransient<ExampleImplA>();
            services.AddScoped<ExampleImplB>();
            services.AddSingleton<ExampleImplStub>();
            
            return services;
        }
    }
}