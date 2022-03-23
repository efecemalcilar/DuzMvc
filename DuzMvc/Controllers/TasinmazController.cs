using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DuzMvc.Dal;
using DuzMvc.Models;

namespace DuzMvc.Controllers
{
    public class TasinmazController : Controller
    {
        private DuzDbContext db = new DuzDbContext();

        // GET: Tasinmaz
        public ActionResult Index()
        {
            var tasinmazes = db.Tasinmazes.Include(t => t.Sahip);
            return View(tasinmazes.ToList());
        }

        // GET: Tasinmaz/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasinmaz tasinmaz = db.Tasinmazes.Find(id);
            if (tasinmaz == null)
            {
                return HttpNotFound();
            }
            return View(tasinmaz);
        }

        // GET: Tasinmaz/Create
        public ActionResult Create()
        {
            ViewBag.SahipId = new SelectList(db.Sahips, "Id", "Name");
            return View();
        }

        // POST: Tasinmaz/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Sehir,Adres,AlinisTarih,AlinisFiyat,SahipId,Aciklama,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Tasinmaz tasinmaz)
        {
            if (ModelState.IsValid)
            {
                db.Tasinmazes.Add(tasinmaz);
                tasinmaz.CreatedDate=DateTime.Now;
                tasinmaz.CreatedBy = "system";
                //Change tracker adında bir system arka planda calisiyor. SaveChanges(); işlemi kadar entitityde ki olabilecek bütün değişikliklerin kaydini tutuyor. Savechange işlemi ile birlikte db ye gönderiyor.
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SahipId = new SelectList(db.Sahips, "Id", "Name", tasinmaz.SahipId);
            return View(tasinmaz);
        }

        // GET: Tasinmaz/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasinmaz tasinmaz = db.Tasinmazes.Find(id);
            if (tasinmaz == null)
            {
                return HttpNotFound();
            }
            ViewBag.SahipId = new SelectList(db.Sahips, "Id", "Name", tasinmaz.SahipId);
            return View(tasinmaz);
        }

        // POST: Tasinmaz/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Sehir,Adres,AlinisTarih,AlinisFiyat,SahipId,Aciklama,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Tasinmaz tasinmaz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tasinmaz).State = EntityState.Modified;
                tasinmaz.UpdatedDate = DateTime.Now;
                tasinmaz.UpdatedBy = "system";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SahipId = new SelectList(db.Sahips, "Id", "Name", tasinmaz.SahipId);
            return View(tasinmaz);
        }

        // GET: Tasinmaz/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasinmaz tasinmaz = db.Tasinmazes.Find(id);
            if (tasinmaz == null)
            {
                return HttpNotFound();
            }
            return View(tasinmaz);
        }

        // POST: Tasinmaz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tasinmaz tasinmaz = db.Tasinmazes.Find(id);
            db.Tasinmazes.Remove(tasinmaz);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
