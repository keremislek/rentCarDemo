using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aracKiralama.Models;

namespace aracKiralama.Controllers
{
    public class VehicleOwnersController : Controller
    {
        // GET: VehicleOwners
        AracKiralaModel model= new AracKiralaModel();
        public ActionResult SirketListele()
        {
            List<VehicleOwners> vo=model.VehicleOwners.ToList();
            List<Vehicles> vehicle=model.Vehicles.ToList();
            ViewBag.vehicle = vehicle;
            ViewBag.vo = vo;
            
            return View();
        }

        [HttpGet]
        public ActionResult SirketEkle()
        {
            List<Users> users=model.Users.ToList();
            ViewBag.users = users;
            VehicleOwners vo=new VehicleOwners();
            return View(vo);
        }
        
        [HttpPost]
        public ActionResult SirketEkle(VehicleOwners vo)
        {
          
            model.VehicleOwners.AddOrUpdate(vo);
            model.SaveChanges();

            return RedirectToAction("SirketListele");
        }
        [HttpGet]
        public ActionResult SirketSil(int id)
        {
            VehicleOwners owners=model.VehicleOwners.FirstOrDefault(x=>x.SahipID==id);
            if (owners != null)
            {
                return View(owners);
            }
            return null;
        }
        [HttpPost]
        public ActionResult SirketSil(VehicleOwners vo)
        {
            vo=model.VehicleOwners.FirstOrDefault(x=>x.SahipID==vo.SahipID);
            if (vo != null)
            {
                model.VehicleOwners.Remove(vo);
                model.SaveChanges();
               
            }
            return RedirectToAction("SirketListele");
        }
        [HttpGet]
        public ActionResult SirketGuncelle(int id)
        {
            VehicleOwners vo = model.VehicleOwners.FirstOrDefault(x => x.SahipID == id);
            List<Users> user=model.Users.ToList();
            ViewBag.user=user;
            if(vo != null)
            {
                return View("SirketEkle", vo);
            }
            return null;

        }
    }
}