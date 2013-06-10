using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using System.Web.Security;
using iLexStudio.IntercomServices.Filters;
namespace IntercomServices.Controllers
{
     [InitializeSimpleMembership]
    public class HomeController : Controller
    {
         public ActionResult Index()
         {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewBag.Button = WebSecurity.IsAuthenticated;
            string temp = "Your are in role ";
            if (!WebSecurity.UserExists(WebSecurity.CurrentUserName))
            {
                return View();
            }
            foreach (string s in Roles.GetRolesForUser(WebSecurity.CurrentUserName))
            {
                temp = temp + " " + s;
            }
            ViewBag.Role = temp;
            return View();
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
