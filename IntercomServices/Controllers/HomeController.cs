using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using System.Web.Security;
using iLexStudio.IntercomServices.Filters;
using iLexStudio.IntercomServices.Models;
using iLexStudio.IntercomServices.Models.Users;

namespace IntercomServices.Controllers
{
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewBag.Authenticated = WebSecurity.IsAuthenticated;
            string temp = "Your are in role ";
            if (!WebSecurity.UserExists(WebSecurity.CurrentUserName))
            {
                return View();
            }
            foreach (string s in Roles.GetRolesForUser(WebSecurity.CurrentUserName))
            {
                temp = temp + " " + s;
            }
            if (WebSecurity.IsAuthenticated)
                ViewBag.UserRole = Roles.GetRolesForUser(WebSecurity.CurrentUserName)[0];
            switch (Roles.GetRolesForUser(WebSecurity.CurrentUserName)[0])
            {
                case "Admin":

                    using (var db = new LoginContexts())
                    {
                        return View(db.UserProfiles.ToList<UserProfile>());
                    }
                case "Operator":
                    using (var db = new LoginContexts())
                    {
                        return View(db.UserProfiles.ToList<UserProfile>());
                    }
                default:
                    return View();
            }
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
