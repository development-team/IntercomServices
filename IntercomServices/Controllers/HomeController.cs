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
using iLexStudio.IntercomServices.Models.Tickets;

namespace IntercomServices.Controllers
{
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewBag.Authenticated = WebSecurity.IsAuthenticated;
            if (!WebSecurity.UserExists(WebSecurity.CurrentUserName))
            {
                WebSecurity.Logout();
                return RedirectToAction("Register","Account");
            }
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
