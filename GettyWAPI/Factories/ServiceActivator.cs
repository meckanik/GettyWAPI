using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using StructureMap;

namespace GettyWAPI.Factories
{
    public class ServiceActivator : IHttpControllerActivator
    {
        private readonly IContainer _container; 

        public ServiceActivator(HttpConfiguration configuration, IContainer container)
        {
            _container = container; 
        }

        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor, 
            Type controllerType)
        {
            return _container.GetInstance(controllerType) as IHttpController;
        }
    }
}