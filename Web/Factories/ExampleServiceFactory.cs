using DotnetDI.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DotnetDI.Application;

namespace DotnetDI.Web.Factories
{
    public class ExampleServiceFactory
    {
        // Lookup and cache implementation type from string value in config
        // This runs automatically on startup and when config is changed (using IOptionsMonitor)
        // Use reflection here to avoid updating factory for each new client
        // We want to avoid reflection at runtime for both performance and safety reasons
        // On request we can retrieve the cached service type based on client name (string) 
        // and instantiate safely because we've already checked against interface requirements

        public ExampleServiceFactory(
            IOptionsMonitor<ClientServiceMappingOptions> config)
        {            
            _cfg = config.CurrentValue;
            UpdateDictionary();
            config.OnChange(cfg =>
            {
                _cfg = cfg;
                UpdateDictionary();                
            });
        }
        // Store/retrieve implementation type by client name 
        private Dictionary<string, Type> _dict = new Dictionary<string, Type>();
        private ClientServiceMappingOptions _cfg;

        private void UpdateDictionary()
        {
            Assembly assembly = typeof(Infrastructure.DependencyInjection).Assembly;// any class in the Infrastructure project will do
            foreach (var client in _cfg.GetType().GetProperties())
            {
                string clientName = client.Name; // config value we'll be passing in at retrieval time
                string implName = client.GetValue(_cfg).ToString();
                string fullTypeName = $"DotnetDI.Infrastructure.Services.ExampleService.{implName}"; // Type name based on convention
                Type implType = assembly.GetType(fullTypeName, true, true); // Use reflection to get Type
                if (implType.GetInterfaces().Contains(typeof(IExampleService))) // Check that this implements required interface (no runtime casting issues)
                {
                    _dict[clientName] = implType; // add to dictionary (or update) for retrieval by client name
                }
            }
        }


        // Generate an instance of the correct implementation for the provided client on request
        public IExampleService GetInstance(string client, IServiceProvider provider)
        {
            var implType = _dict.GetValueOrDefault(client);
            return (IExampleService)provider.GetRequiredService(implType);
        }
    }
}
