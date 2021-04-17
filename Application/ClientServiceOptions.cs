namespace DotnetDI.Application
{
    public class ClientServiceMappingOptions
    {
        // top level config setting, here just to add type safety to Startup
        public const string ClientServiceMappings = "ClientServiceMappings";
        // children, the values for which we want to live reload
        public string Client1 { get; set; }
        public string Client2 { get; set; }
        public string Client3 { get; set; } 
        // add new client as it is migrated onto the platform
    }
}
