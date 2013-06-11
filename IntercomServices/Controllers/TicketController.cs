using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using iLexStudio.IntercomServices.Models;
using iLexStudio.IntercomServices.Models.Tickets;
using iLexStudio.IntercomServices.Models.Users;
using System.Data.Entity.Validation;
using System.Web.Security;

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
                db.Tickets.Add(new Ticket { Assignee = 1, BuildingID = model.BuildingID, CallerName = model.CallerName, Description = model.Description, Email = model.Email, Phone = model.Phone, Status = TicketStatus.New, StatusReason = "New ticket" });
                try
                {

                    db.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpGet]
        public ActionResult Edit(EditModel model, int ObjectID)
        {
            if (WebSecurity.IsAuthenticated && Roles.GetRolesForUser(WebSecurity.CurrentUserName).Contains("Operator"))
            {
                ViewBag.id = ObjectID;
                using (var db = new IntercomContext())
                {
                    Ticket ticket = db.Tickets.Find(ObjectID);
                    if (ticket == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        model.ObjectID = ticket.ObjectID;
                        model.CallerName = ticket.CallerName;
                        model.BuildingID = ticket.BuildingID;
                        model.Phone = ticket.Phone;
                        model.Email = ticket.Email;
                        model.StatusReason = ticket.StatusReason;
                        model.Assignee = ticket.Assignee;
                        model.Status = ticket.Status;
                        model.Description = ticket.Description;
                    }
                }
                return View(model);

            }

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Edit(EditModel model)
        {
            using (var db = new IntercomContext())
            {
                Ticket EditedTicket = db.Tickets.Find(model.ObjectID);
                EditedTicket.Assignee = model.Assignee;
                EditedTicket.BuildingID = model.BuildingID;
                EditedTicket.CallerName = model.CallerName;
                EditedTicket.Description = model.Description;
                EditedTicket.Email = model.Email;
                EditedTicket.Phone = model.Phone;
                EditedTicket.Status = model.Status;
                EditedTicket.StatusReason = model.StatusReason;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Add(int UserID, int TicketID)
        {
            using (var db = new IntercomContext())
            {
                Ticket ticket = db.Tickets.Find(TicketID);
                if (ticket == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    ticket.Assignee = UserID;
                    ticket.Status = TicketStatus.Assigned;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
        }

    }

}
