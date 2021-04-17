using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using DotnetDI.Web.Factories;

namespace DotnetDI.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogger<ApiController> _logger;
        private readonly ExampleServiceFactory _exampleServiceFactory;
        private readonly IServiceProvider _serviceProvider;

        public ApiController(
            IConfiguration config,
            ILogger<ApiController> logger,
            ExampleServiceFactory exampleServiceFactory,
            IServiceProvider serviceProvider
        )
        {
            _config = config;
            _logger = logger;
            _exampleServiceFactory = exampleServiceFactory;
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public string Get()
        {
            var client1Service = _exampleServiceFactory.GetInstance("Client1", _serviceProvider);
            var client2Service = _exampleServiceFactory.GetInstance("Client2", _serviceProvider);
            var client3Service = _exampleServiceFactory.GetInstance("Client3", _serviceProvider);
            return $" Client1: {client1Service.Action()} \r\n Client2: {client2Service.Action()} \r\n Client3: {client3Service.Action()}";
        }
    }
}
