using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace BookReviewsAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //WebAPI to be configured to return only JSON result. 
            //Web API to respond only to URL with api/ControllerName/ActionName
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
        }
    }
}
