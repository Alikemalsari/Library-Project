using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LibraryProject.Models;

namespace LibraryProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        LibraryDBEntities1 db = new LibraryDBEntities1();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Indexx(Account t)
        {
            var query = db.Accounts.FirstOrDefault(x => x.KullaniciAdi == t.KullaniciAdi && x.Sifre == t.Sifre);
            if (query != null)
            {
                FormsAuthentication.SetAuthCookie(query.KullaniciAdi, false);
                ViewBag.hata = "";
                return RedirectToAction("Index", "Admin");
            }

            else
            {
                ViewBag.hata = "Kullanıcı adınız veya şifreniz hatalı";
                return View();
            }

        }
    }
}