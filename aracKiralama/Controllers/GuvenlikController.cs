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
                //FormsAuthentication.SetAuthCookie(user.KullaniciAdi, false);
                Session["UserID"] = user.KullaniciID;
                Session["UserName"] = user.KullaniciAdi;


                var encodedTicket = FormsAuthentication.Encrypt(
                   new FormsAuthenticationTicket(
                      user.KullaniciID,
                      user.KullaniciAdi,
                      DateTime.Now,
                      DateTime.UtcNow.Add(FormsAuthentication.Timeout),
                      true,
                      user.ToString()));

                var httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encodedTicket);
                Response.Cookies.Add(httpCookie);
                
                
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

            VehicleOwners vehicle = new VehicleOwners();
            
                model.Users.Add(user);
                model.SaveChanges();
                vehicle.KullaniciID = user.KullaniciID;

                if (user.RolID == 3)
                {

                    return RedirectToAction("SirketEkle", "VehicleOwners",vehicle);
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