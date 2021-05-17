using Lab.EF.API.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Lab.EF.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            config.EnableCors(new AccessPolicyCors());
            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
