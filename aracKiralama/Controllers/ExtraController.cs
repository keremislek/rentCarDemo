using aracKiralama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aracKiralama.Controllers
{
    public class ExtraController : Controller
    {
        // GET: Extra
        AracKiralaModel model=new AracKiralaModel();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ExtraSor()
        {
   
            return View();
        }
        public ActionResult ExtraListele()
        {
            List<Extras> extras = model.Extras.ToList();
            ViewBag.extras=extras;
            return View();  
        }
      
    }
}