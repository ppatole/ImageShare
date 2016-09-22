using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //route for login Page
            routes.MapRoute("Login", "login", new { controller = "Account", action = "Login" });

            //route for login Page
            routes.MapRoute("ChangePassword", "changepassword", new { controller = "MyUser", action = "ChangePassword" });

            //route for Home Page
            routes.MapRoute("Home", "", new { controller = "Home", action = "Index"});

            //route for User Home
            routes.MapRoute("UserHome", "user", new { controller = "MyUser", action = "UserHome" });

            //route for User Management
            routes.MapRoute("ManageUser", "user/{act}/{id}", new { controller = "MyUser", action = "ManageUser", id = UrlParameter.Optional });

            //route for Participant Home
            routes.MapRoute("ParticipantHome", "participant", new { controller = "Participant", action = "ParticipantHome" });

            //route for Participant Management
            routes.MapRoute("ManageParticipant", "participant/{act}/{id}", new { controller = "Participant", action = "ParticipantMain", id = UrlParameter.Optional });
            
            //Reports Home Page
             //route for Participant Home
            routes.MapRoute("ReportHome", "report", new { controller = "Report", action = "ReportMain" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
