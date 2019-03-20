using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StructureMap;
using WebApi.StructureMap;

namespace GettyWAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // dependancy injection for the controllers
            GlobalConfiguration.Configuration.UseStructureMap<Registry>();

            //var container = new Container();

            //var config = GlobalConfiguration.Configuration; 
            //config.Services.Replace(typeof(IHttpControllerActivator), 
            //    new ServiceActivator(config, container));


            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            


        }
    }
}
