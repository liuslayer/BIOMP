using BIOMP.Web.Unity;
using BIOMP.Web.WebAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace BIOMP.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            // Web API 配置和服务
            config.Filters.Add(new CustomExceptionAttribute());
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            config.DependencyResolver = new UnityDependencyResolver(UnityContainerFactory.GetContainer());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "BPApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
);
        }
    }
}
