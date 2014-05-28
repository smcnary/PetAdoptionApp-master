using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PetApp.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "WalkADog",
                url: "Walk/{dogName}",
                defaults: new { controller = "Home", action = "Walk", dogName = UrlParameter.Optional }
                
                );

            routes.MapRoute(
                name: "PetDetail",
                url: "Pet/{petName}",
                defaults: new { controller = "Home", action = "PetDetail", petName = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Adoption",
                url: "Adopt/{petName}",
                defaults: new { controller = "Home", action = "Adoption", petName = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
