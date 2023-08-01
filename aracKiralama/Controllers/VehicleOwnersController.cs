﻿using System;
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
            ViewBag.vehicleOwners = vo;
            Vehicles vehicles = new Vehicles();
            return View(vehicles);
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
            model.VehicleOwners.Add(vo);
            model.SaveChanges();

            return RedirectToAction("SirketListele");
        }
    }
}