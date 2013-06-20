using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iLexStudio.IntercomServices.Models;

namespace iLexStudio.IntercomServices.Controllers
{
    public class AddressController : Controller
    {
        private IntercomContext db = new IntercomContext();

        //
        // GET: /Address/

        public ActionResult Index()
        {
            return View(db.Addresses.ToList());
        }

        //
        // GET: /Address/Details/5

        public ActionResult Details(int id = 0)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }


        //
        // GET: /Address/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Address/Create

        [HttpPost]
        public ActionResult Create(Address address)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(address);
        }

        //
        // GET: /Address/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        //
        // POST: /Address/Edit/5

        [HttpPost]
        public ActionResult Edit(Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(address);
        }

        //
        // GET: /Address/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        //
        // POST: /Address/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }



        public int GetIdOfAddressFromDbByOtherValues(string street, string home, string appartment )
        {    List<Address> addresses = new List<Address>();
              addresses = db.Addresses.Where(t => t.Street == street)
                                                  .Where(t => t.Home == home)
                                                  .Where(t => t.Appartment== appartment)
                                                  .ToList();
            if (addresses.Count ==0)
            {
                return -1; // addreess not found in the database 
            }
            else
            {
                return addresses[addresses.Count - 1].AddressID; //
            }

        }

    }
}