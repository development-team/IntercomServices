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
             // As described in the specificatio status of the new ticket should be =2
             _db.Tickets.Add(new Ticket { Assignee = "", AddressID = model.AddressID, CallerName = model.CallerName, Description = model.Description, Email = model.Email, Phone = model.Phone, StatusID = "2", StatusReason = "1" });
            _db.SaveChanges();
            return View(model);
        }

        [HttpGet]
        public String ListOfTickets(string returnUrl, String street, string home, string appartment )
        {
              
             var ListOfTickets = from address in _db.Addresses
                                join ticket in _db.Tickets on address.AddressID equals ticket.AddressID
                                 where ((street.Length > -1)? address.Street.Contains(street): true) && ((home.Length > -1) ? address.Home.Contains(home) : true) && ((appartment.Length > -1) ? address.Appartment.Contains(appartment) : true)
                                select new
                                {
                                    ticket.TicketID,
                                    ticket.Description,
                                    address.Street,
                                    address.Home,
                                    address.Appartment
                                };
      

            ViewBag.ReturnUrl = returnUrl;

           String htmlTable ="<table>";
            foreach (var ticket in ListOfTickets)
            {
                htmlTable = htmlTable+"<tr><td>" + ticket.TicketID + "</td><td>" + ticket.Description + "</td><td>" + ticket.Street + "</td><td>" + ticket.Home + "</td><td>" + ticket.Appartment + "</td><td>" + "</td></tr>";
            }
            htmlTable = htmlTable+ "</table>";
            return htmlTable;
        }
    }
}
