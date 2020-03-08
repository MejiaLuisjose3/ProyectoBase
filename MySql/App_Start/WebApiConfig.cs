using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Routing;


namespace MySql
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var hosts = ConfigurationManager.AppSettings["ALLOWED_HOSTS"];
            var headers = ConfigurationManager.AppSettings["ALLOWED_HEADERS"];
            var methods = ConfigurationManager.AppSettings["ALLOWED_METHODS"];
            var urlPermitidas = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(urlPermitidas);

            // Web API routes
            config.MapHttpAttributeRoutes(new CustomDirectRouteProvider());

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //config.Filters.Add(new HandleApiExceptionAttribute());
            //config.Services.Replace(typeof(IExceptionLogger), new GlobalExceptionLogger());
            //config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());


        }

        public class CustomDirectRouteProvider : DefaultDirectRouteProvider
        {
            protected override IReadOnlyList<IDirectRouteFactory>
                GetActionRouteFactories(HttpActionDescriptor actionDescriptor)
            {
                return actionDescriptor.GetCustomAttributes<IDirectRouteFactory>
                    (inherit: true);
            }
        }
    }
}
