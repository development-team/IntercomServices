using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using iLexStudio.IntercomServices.Models;


namespace iLexStudio.IntercomServices.Controllers
{
    public class TicketController : Controller
    {
        private IntercomContext _db = new IntercomContext();
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
            if (!WebSecurity.IsAuthenticated)            
                ModelState.AddModelError("", "Please Log in first");
            _db.Tickets.Add(new Ticket { Assignee = "", BuildingID = model.BuildingID, CallerName = model.CallerName, Description = model.Description, Email = model.Email, Phone = model.Phone, Status = "", StatusReason = ""});
            _db.SaveChanges();
            return View(model);
        }

    }
}
