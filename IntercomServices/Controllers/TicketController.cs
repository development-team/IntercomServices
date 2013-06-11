using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using iLexStudio.IntercomServices.Models;
using iLexStudio.IntercomServices.Models.Tickets;
using iLexStudio.IntercomServices.Models.Users;


namespace iLexStudio.IntercomServices.Controllers
{
    public class TicketController : Controller
    {
       
        //
        // GET: /Ticket/

        public ActionResult Create(string returnUrl)
        {           
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateModel model, string returnUrl)
        {

            using (var db = new IntercomContext())
            {

                if (!WebSecurity.IsAuthenticated)
                    ModelState.AddModelError("", "Please Log in first");
                //db.Tickets.Add(new Ticket { Assignee = 1, BuildingID = model.BuildingID, CallerName = model.CallerName, Description = model.Description, Email = model.Email, Phone = model.Phone });
               // db.SaveChanges();
                return View(model);
            }
           
        }

    }
}
