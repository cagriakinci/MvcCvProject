using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        // Index'te zaten listeleme yaptığımız için güncellemenin post tarafınıda Index'ten yaptık.
        [HttpPost]
        public ActionResult Index(TblHobilerim p)
        {
            var hobiBul = repo.Find(x => x.ID == 1);
            hobiBul.Aciklama1 = p.Aciklama1;
            hobiBul.Aciklama2 = p.Aciklama2;
            repo.TUpdate(hobiBul);
            return RedirectToAction("Index");
        }
    }
}