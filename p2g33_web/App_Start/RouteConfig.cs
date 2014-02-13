using System.Web.Mvc;
using System.Web.Routing;

namespace p2g33_web.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "{controller}/{action}", new {controller = "Home", action = "Index"});






        }
    }
}