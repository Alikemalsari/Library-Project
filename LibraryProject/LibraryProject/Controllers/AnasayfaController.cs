using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models;
using PagedList;
using PagedList.Mvc;

namespace LibraryProject.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        LibraryDBEntities1 db = new LibraryDBEntities1();
        public ActionResult Index(int sayfa=1)
        {
            var query = db.Kitaplars.Where(x => x.KitapStatus == true).ToList().ToPagedList(sayfa,10);
            return View(query);
        }

        public ActionResult Kirala(int Id)
        {
            var entity = db.Kitaplars.FirstOrDefault(x => x.KitapId == Id);


            KitaplarViewModel model = new KitaplarViewModel();
            model.KitapId = entity.KitapId;
            model.KitapAdi = entity.KitapAdi;
            model.Yazari = entity.Yazari;



            return View(model);

        }

        [HttpPost]
        public ActionResult Kirala(KiralamaViewModel t)
        {
            var entity = db.Kitaplars.FirstOrDefault(x => x.KitapId == t.KitapId);

            var save = new Kiralama()
            {
                KitabiAlan = t.KitabiAlan,
                KitapAdi = entity.KitapAdi,
                IadeZamani = t.IadeZamani
  
            };
            entity.KitapStatus = false;
            db.Kiralamas.Add(save);
            db.SaveChanges();



            return RedirectToAction("Index","Anasayfa");

        }

       

       
    }
}