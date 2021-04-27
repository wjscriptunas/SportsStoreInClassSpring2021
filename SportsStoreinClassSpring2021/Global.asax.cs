using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SportsStoreinClassSpring2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SportsStoreinClassSpring2021
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if(!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
            if(!roleManager.RoleExists("Administrator"))
            {
                var role = new IdentityRole();
                role.Name = "Administrator";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.Email = "adminuser1@test.com";
                user.UserName = "adminuser1@test.com";

                var userCreated = UserManager.Create(user, "Test1234!");

                if(userCreated.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Administrator");
                }
            }

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}