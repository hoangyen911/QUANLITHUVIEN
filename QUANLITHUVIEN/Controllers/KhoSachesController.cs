using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QUANLITHUVIEN.Models;

namespace QUANLITHUVIEN.Controllers
{
    public class KhoSachesController : Controller
    {
        private QUANLITHUVIENDbContext db = new QUANLITHUVIENDbContext();

        // GET: KhoSaches
        public ActionResult Index()
        {
            return View(db.KhoSachs.ToList());
        }

        // GET: KhoSaches/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoSach khoSach = db.KhoSachs.Find(id);
            if (khoSach == null)
            {
                return HttpNotFound();
            }
            return View(khoSach);
        }

        // GET: KhoSaches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhoSaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKho,TenKho,GhiChu")] KhoSach khoSach)
        {
            if (ModelState.IsValid)
            {
                db.KhoSachs.Add(khoSach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khoSach);
        }

        // GET: KhoSaches/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoSach khoSach = db.KhoSachs.Find(id);
            if (khoSach == null)
            {
                return HttpNotFound();
            }
            return View(khoSach);
        }

        // POST: KhoSaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKho,TenKho,GhiChu")] KhoSach khoSach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khoSach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khoSach);
        }

        // GET: KhoSaches/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoSach khoSach = db.KhoSachs.Find(id);
            if (khoSach == null)
            {
                return HttpNotFound();
            }
            return View(khoSach);
        }

        // POST: KhoSaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KhoSach khoSach = db.KhoSachs.Find(id);
            db.KhoSachs.Remove(khoSach);
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
