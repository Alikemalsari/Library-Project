using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models;

namespace LibraryProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        LibraryDBEntities1 db = new LibraryDBEntities1();
        public ActionResult Index()
        {
            var query = db.Kitaplars.Where(x => x.KitapStatus == true).ToList();
            return View(query);
        }

        public ActionResult Edit(int Id)
        {
            
                var entity = db.Kitaplars.FirstOrDefault(x => x.KitapId == Id);


                KitaplarViewModel model = new KitaplarViewModel();
                model.KitapId = entity.KitapId;
                model.KitapAdi = entity.KitapAdi;
                model.Yazari = entity.Yazari;
                

                return View(model);
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KitaplarViewModel model)
        {

                    var entity = db.Kitaplars.FirstOrDefault(x => x.KitapId == model.KitapId);

                    entity.KitapAdi = model.KitapAdi;
                    entity.Yazari = model.Yazari;
                   
                    db.SaveChanges();


                    TempData["succes"] = true;

            return RedirectToAction("Index", "Admin");


        }



        public ActionResult Delete(int id)
        {

                var entity = db.Kitaplars.FirstOrDefault(x => x.KitapId == id);

                entity.KitapStatus = false;
                db.SaveChanges();


                return RedirectToAction("Index","Admin");

            
        }
        public ActionResult YeniKitap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKitap(Kitaplar t)
        {

            Kitaplar arc = new Kitaplar();
           
                arc.KitapAdi = t.KitapAdi;
                arc.Yazari = t.Yazari;
                arc.KitapStatus = t.KitapStatus;
               
                db.Kitaplars.Add(arc);
                db.SaveChanges();
            
            return RedirectToAction("Index", "Admin");

        }

        

        public ActionResult Iade()
        {
            var query = db.Kiralamas.ToList();
            return View(query);

        }
        
        public ActionResult IadeEt(String t)
        {
            var query = db.Kitaplars.FirstOrDefault(x => x.KitapAdi == t);
            var iade = db.Kiralamas.FirstOrDefault(s => s.KitapAdi == t);
            query.KitapStatus = true;
            db.Kiralamas.Remove(iade);
            
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
            

        }

    }
}