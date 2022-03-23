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
    public class SahipController : Controller
    {
        private DuzDbContext db = new DuzDbContext();

        // GET: Sahip
        public ActionResult Index()
        {
            return View(db.Sahips.ToList());
        }

        // GET: Sahip/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sahip sahip = db.Sahips.Find(id);
            if (sahip == null)
            {
                return HttpNotFound();
            }
            return View(sahip);
        }

        // GET: Sahip/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sahip/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DTarih,Idno,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Sahip sahip)
        {
            if (ModelState.IsValid)
            {
                db.Sahips.Add(sahip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sahip);
        }

        // GET: Sahip/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sahip sahip = db.Sahips.Find(id);
            if (sahip == null)
            {
                return HttpNotFound();
            }
            return View(sahip);
        }

        // POST: Sahip/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DTarih,Idno,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Sahip sahip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sahip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sahip);
        }

        // GET: Sahip/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sahip sahip = db.Sahips.Find(id);
            if (sahip == null)
            {
                return HttpNotFound();
            }
            return View(sahip);
        }

        // POST: Sahip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sahip sahip = db.Sahips.Find(id);
            db.Sahips.Remove(sahip);
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
