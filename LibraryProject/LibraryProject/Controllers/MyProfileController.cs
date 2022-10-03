using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models;

namespace LibraryProject.Controllers
{
    public class MyProfileController : Controller
    {
        // GET: MyProfile
        LibraryDBEntities1 db = new LibraryDBEntities1();
        public ActionResult Index()
        {
            var query = db.Accounts.ToList();
            return View(query);
        }

        public ActionResult edit(int id)
        {
            var query = db.Accounts.FirstOrDefault(x => x.AccountId == id);
            AccountViewModel model = new AccountViewModel();
            model.Id = query.AccountId;
            model.IsimSoyisim = query.IsimSoyisim;
            model.EMail = query.EMail;
            model.KullaniciAdi = query.KullaniciAdi;
            model.Sifre = query.Sifre;
            return View(model);
        }

        [HttpPost]
        public ActionResult edit(AccountViewModel model)
        {
            var query = db.Accounts.FirstOrDefault(x => x.AccountId == model.Id);
            query.IsimSoyisim = model.IsimSoyisim;
            query.EMail = model.EMail;
            query.KullaniciAdi = model.KullaniciAdi;
            query.Sifre = model.Sifre;
            db.SaveChanges();
            TempData["succes"] = true;

            return RedirectToAction("Index", "MyProfile");

        }

       
    }
}