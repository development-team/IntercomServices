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
             //Address address = new Address(model.Street, model.Home, model.Appartment);
             AddressController addressController = new AddressController ();
             model.AddressID = addressController.GetIdOfAddressFromDbByOtherValues(model.Street, model.Home, model.Appartment);
             if (model.AddressID == -1)
             {
                 Address address = new Address(model.Street, model.Home, model.Appartment);
                 _db.Addresses.Add(address);
                 _db.SaveChanges();
                 model.AddressID = address.AddressID;
              }
             _db.Tickets.Add(new Ticket { Assignee = "", AddressID = model.AddressID, CallerName = model.CallerName, Description = model.Description, Email = model.Email, Phone = model.Phone, StatusID = "1", StatusReason = "1" });
            _db.SaveChanges();
            return View(model);
        }

    }
}
