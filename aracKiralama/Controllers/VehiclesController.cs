using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aracKiralama.Models;
using aracKiralama.Security;

namespace aracKiralama.Controllers
{
    public class VehiclesController : Controller
    {
        //1:Admin 2:Kullanici 3:Şirket
        // GET: Vehicles
        AracKiralaModel model = new AracKiralaModel();

        [MyAuthorization(Roles = "1,2,3")]
        public ActionResult AraclariListele()
        {
            List<Vehicles> v = model.Vehicles.ToList();
            ViewBag.vehicles = v;

            return View();
        }

        [HttpGet]
        [Authorize]
        [MyAuthorization(Roles = "3")]
        public ActionResult AracEkle()
        {
            List<VehicleOwners> vehicleOwners = model.VehicleOwners.ToList();
            ViewBag.vehicleOwners = vehicleOwners;
            Vehicles v = new Vehicles();

            return View(v);
        }
        [HttpPost]
        [Authorize]
        [MyAuthorization(Roles = "3")]
        public ActionResult AracEkle(Vehicles vehicle)
        {
            model.Vehicles.Add(vehicle);
            model.SaveChanges();

            return RedirectToAction("AraclariListele");
        }

        [HttpGet]
        [MyAuthorization(Roles = "1,3")]
        public ActionResult AracSil(int id)
        {
            Vehicles vehicles = model.Vehicles.FirstOrDefault(x => x.AracID == id);
            if (vehicles != null)
            {
                return View(vehicles);
            }

            return null;
        }
        [HttpPost]
        [MyAuthorization(Roles = "1,3")]
        public ActionResult AracSil(Vehicles vehicles)
        {
            vehicles = model.Vehicles.FirstOrDefault(x => x.AracID == vehicles.AracID);
            if (vehicles != null)
            {
                model.Vehicles.Remove(vehicles);
                model.SaveChanges();
            }
            return RedirectToAction("AraclariListele");
        }
        [HttpGet]
        [MyAuthorization(Roles="1,3")]
        public ActionResult AracGuncelle(int id)
        {
            Vehicles v=model.Vehicles.FirstOrDefault(x=>x.AracID==id);
            List<VehicleOwners> vehicleOwners=model.VehicleOwners.ToList();
            ViewBag.VehicleOwners = vehicleOwners;
            if(v != null)
            {
                return View("AracEkle", v);
            }
            return null;
        }
    }
}