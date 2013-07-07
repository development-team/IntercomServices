using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using WebMatrix.WebData;
using iLexStudio.IntercomServices.Models;
using System.IO;


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
             _db.Tickets.Add(new Ticket { Assignee = "", AddressID = model.AddressID, CallerName = model.CallerName, Description = model.Description, Email = model.Email, Phone = model.Phone, StatusID = 2, StatusReason = "1" });
            _db.SaveChanges();
            return View(model);
        }

        [HttpGet]
        public String ListOfTickets(string returnUrl, String street, string home, string appartment)
        {
            String html = "";
             var ListOfTickets = from address in _db.Addresses
                                join ticket in _db.Tickets on address.AddressID equals ticket.AddressID
                                 where ((street.Length > -1) ? address.Street.Contains(street) : true) && ((home.Length > -1) ? address.Home.Contains(home) : true) && ((ticket.StatusID < 32) || (((appartment.Length > -1) ? address.Appartment.Contains(appartment) : true) && (ticket.StatusID < 4)))
                                 select new
                                {
                                    ticket.TicketID,
                                    ticket.Description,
                                    address.Street,
                                    address.Home,
                                    address.Appartment,
                                    ticket.StatusID
                                };

            
            Table htmlTable = new Table();
          
            foreach (var ticket in ListOfTickets)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();

                RadioButton radioButton = new RadioButton();
                radioButton.ID =  ticket.TicketID.ToString();
                radioButton.GroupName = "ExistedTickets";
                cell.Controls.Add(radioButton);
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = ticket.Description;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = ticket.Street;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = ticket.Home;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = ticket.Appartment;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = Enum.GetName(typeof(TicketStatus), ticket.StatusID);
                row.Cells.Add(cell);

                htmlTable.Rows.Add(row);
            }
            using (StringWriter sw = new StringWriter())
            {
                htmlTable.RenderControl(new HtmlTextWriter(sw));
                html = sw.ToString();
            }
            return html;
        }
    }
}
