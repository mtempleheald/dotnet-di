using DotnetDI.Application.Interfaces;
using System;

namespace DotnetDI.Infrastructure.Services.ExampleService
{
    public class ExampleImplStub : IExampleService
    {
        private DateTime _created;
        public ExampleImplStub () {
            _created = DateTime.Now;
        }
        public string Action()
        {
            DateTime called = DateTime.Now;
            return $"ExampleImplStub.Action - created {_created}, called {called}";
        }
    }
}
