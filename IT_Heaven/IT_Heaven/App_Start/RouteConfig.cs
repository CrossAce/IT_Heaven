using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IT_Heaven
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Categories",
                url: "Categories/SingleCategory",
                defaults: new { controller = "Categories", action = "SingleCategory" }
             );
            routes.MapRoute(
                name: "Categories with Id",
                url: "Categories/SingleCategory/{categoryId}",
                defaults: new { controller = "Categories" , action = "SingleCategory" , categoryId = 1 }
             );
         
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
         
        }
    }
}
