using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using aracKiralama.Models;
using aracKiralama.Security;

namespace aracKiralama.Controllers
{
    public class RentalsController : Controller
    {
        // GET: Rentals
        AracKiralaModel model = new AracKiralaModel();
        public ActionResult Index()
        {
            var db = model.Rentals.Include("Customers").Include("Vehicles").ToList();
            List<Rentals> rental = model.Rentals.ToList();
            return View(db);
        }
        [HttpPost]
        [Authorize]  
        public ActionResult AracKirala(Rentals rental)
        {
            if (rental != null)
            {
                model.Rentals.Add(rental);
                model.SaveChanges();

                return RedirectToAction("AracKirala","Payments",rental);
            }
            return null;
        }
        [HttpGet]
        public ActionResult AracKirala(Int32 id = 0)
        {


            List<Vehicles> vehicles = model.Vehicles.ToList();
            List<Customers> customers = model.Customers.ToList();
            List<Cities> cities= model.Cities.ToList();
            List<Extras> extras= model.Extras.ToList();
            ViewBag.extras = extras;
            ViewBag.cities= cities;
            ViewBag.vehicles = vehicles;
            ViewBag.customers = customers;
            //vehicles.Where();  url VID  + CID
            Rentals rentals = new Rentals();
            rentals.AracID = id;
            Vehicles v1=model.Vehicles.FirstOrDefault(x=>x.AracID==id);
            rentals.ToplamFiyat = v1.KiralamaFiyati;
            
        
            return View(rentals);

        }
        public ViewResult Details(int id)
        {


            return View();
        }

    }
}