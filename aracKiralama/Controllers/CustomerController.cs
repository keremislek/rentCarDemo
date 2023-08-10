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

        [HttpGet]
        public ActionResult MusteriListele()
        {
            List<Customers> customer=model.Customers.ToList();

            if (User.IsInRole("2")) // Eğer giriş yapan kullanıcı müşteri ise
            {
                string kullaniciAdi = User.Identity.Name;
                Users user = model.Users.FirstOrDefault(u => u.KullaniciAdi == kullaniciAdi);

                if (user != null)
                {
                    customer = model.Customers.Where(c => c.KullaniciID == user.KullaniciID).ToList();
                }
            }
            else if (User.IsInRole("1") || User.IsInRole("3")) // Eğer giriş yapan kullanıcı admin veya şirket ise
            {
                customer = model.Customers.ToList();
            }


            ViewBag.customer=customer;
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

            return RedirectToAction("Index","Home");
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