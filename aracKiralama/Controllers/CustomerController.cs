using aracKiralama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aracKiralama.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        AracKiralaModel model=new AracKiralaModel();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MusteriEkle()
        {
            List<Users> users = model.Users.ToList();
            ViewBag.users = users;
            Customers customers = new Customers();
            return View(customers);
        }

        [HttpPost]
        public ActionResult MusteriEkle(Customers customer)
        {
        
            model.Customers.Add(customer);
            model.SaveChanges();

            return RedirectToAction("AraclariListele","Vehicles");
        }
        [HttpGet]
        public ActionResult MusteriSil(int id)
        {
            Customers customer = model.Customers.FirstOrDefault(x=>x.MusteriID==id);
            if (customer != null)
            {
                return View(customer);
            }
            else
            {
                return null;
            }
            
        }
        [HttpPost]
        public ActionResult MusteriSil(Customers customer)
        {
            customer=model.Customers.FirstOrDefault(x=>x.MusteriID == customer.MusteriID);
            if (customer!=null)
            {
                model.Customers.Remove(customer);
                model.SaveChanges();
            }
            
            return RedirectToAction("AraclariListele","Vehicles");
        }
    }
}