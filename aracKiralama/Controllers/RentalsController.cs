using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aracKiralama.Models;

namespace aracKiralama.Controllers
{
    public class RentalsController : Controller
    {
        // GET: Rentals
        AracKiralaModel model= new AracKiralaModel();
        public ActionResult Index()
        {
            var db=model.Rentals.Include("Customers").Include("Vehicles").ToList();
            List<Rentals> rental=model.Rentals.ToList();
            return View(db);
        }
        [HttpPost]
        public ActionResult AracKirala(Rentals rental)
        {
            if(rental!=null) { 
            model.Rentals.AddOrUpdate(rental);
            model.SaveChanges();
            return RedirectToAction("AraclariListele");
        }
            return null;
        }
        [HttpGet]
        public ActionResult AracKirala() {
           
            return View();
        }
    }
}