using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aracKiralama.Models;

namespace aracKiralama.Controllers
{
    
    public class HomeController : Controller
    {
        // GET: Home
        AracKiralaModel model = new AracKiralaModel();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Kayıt(Users user)
        {   
            return View(user);
        }


    }
}