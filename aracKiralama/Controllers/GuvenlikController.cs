using aracKiralama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace aracKiralama.Controllers
{
    [Authorize]
    public class GuvenlikController : Controller
    {
        // GET: Guvenlik
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Users users)
        {
            AracKiralaModel model = new AracKiralaModel();  
            Users user=model.Users.FirstOrDefault(x=>x.KullaniciAdi==users.KullaniciAdi && x.Sifre==users.Sifre);
            if (user == null)
            {
                return ViewBag.hata = "Kullanıcı adı veya şifre hatalı";
            }
            else
            {
                FormsAuthentication.SetAuthCookie(user.KullaniciAdi, false);
                return RedirectToAction("Index", "Home");
            }
           
        }
        
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult Hata()
        {
            return View();
        }
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult SignUp()
        {
            AracKiralaModel model = new AracKiralaModel();
            Users user= new Users();
            return View(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SignUp(Users user)
        {
            AracKiralaModel model =new AracKiralaModel();
            
                model.Users.Add(user);
                model.SaveChanges();

                if (user.RolID == 3)
                {
                    return RedirectToAction("SirketEkle", "VehicleOwners");
                }
                else if(user.RolID == 2)
                {
                    return RedirectToAction("MusteriEkle","Customers");

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            

           
        }
    }
}