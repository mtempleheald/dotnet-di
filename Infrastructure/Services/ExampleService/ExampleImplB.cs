using DotnetDI.Application.Interfaces;
using System;

namespace DotnetDI.Infrastructure.Services.ExampleService
{
    public class ExampleImplB : IExampleService
    {
        private DateTime _created;
        public ExampleImplB () {
            _created = DateTime.Now;
        }
        public string Action()
        {
            DateTime called = DateTime.Now;
            return $"ExampleImplB.Action - created {_created}, called {called}";
        }
    }
}
