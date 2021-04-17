using DotnetDI.Application.Interfaces;
using System;

namespace DotnetDI.Infrastructure.Services.ExampleService
{
    public class ExampleImplA : IExampleService
    {
        private DateTime _created;
        public ExampleImplA () {
            _created = DateTime.Now;
        }
        public string Action()
        {
            DateTime called = DateTime.Now;
            return $"ExampleImplA.Action - created {_created}, called {called}";
        }
    }
}
