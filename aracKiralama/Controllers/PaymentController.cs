using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aracKiralama.Models;

namespace aracKiralama.Controllers
{
    public class PaymentsController : Controller
    {
        AracKiralaModel model = new AracKiralaModel();

        // GET: Payments
        public ActionResult Index()
        {
            List<Payments> payments = model.Payments.ToList();
            return View(payments);
        }

        // GET: Payments/Create
        [HttpGet]
        public ActionResult AracKirala(int kiralamaID)
        {
           
            ViewBag.kiralamaID = kiralamaID;
            Rentals r1=model.Rentals.FirstOrDefault(x=>x.KiralamaID==kiralamaID);
            Payments payments = new Payments();
            payments.OdemeMiktari = r1.ToplamFiyat;
            payments.KiralamaID=kiralamaID;
            return View(payments);
        }

        // POST: Payments/Create
        [HttpPost]
        public ActionResult AracKirala(Payments payment)
        {
            if (payment!=null)
            {
                model.Payments.Add(payment);
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(payment);
        }

      
    
    }
}
