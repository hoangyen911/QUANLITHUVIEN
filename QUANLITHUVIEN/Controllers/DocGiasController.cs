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
    public class DocGiasController : Controller
    {
        private QUANLITHUVIENDbContext db = new QUANLITHUVIENDbContext();

        // GET: DocGias
        public ActionResult Index()
        {
            return View(db.DocGias.ToList());
        }

        // GET: DocGias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia docGia = db.DocGias.Find(id);
            if (docGia == null)
            {
                return HttpNotFound();
            }
            return View(docGia);
        }

        // GET: DocGias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocGias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoThe,HoTen,NgaySinh,GioiTinh,ChoOHienTai,NgayCapThe,HanDungThe")] DocGia docGia)
        {
            if (ModelState.IsValid)
            {
                db.DocGias.Add(docGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(docGia);
        }

        // GET: DocGias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia docGia = db.DocGias.Find(id);
            if (docGia == null)
            {
                return HttpNotFound();
            }
            return View(docGia);
        }

        // POST: DocGias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoThe,HoTen,NgaySinh,GioiTinh,ChoOHienTai,NgayCapThe,HanDungThe")] DocGia docGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(docGia);
        }

        // GET: DocGias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia docGia = db.DocGias.Find(id);
            if (docGia == null)
            {
                return HttpNotFound();
            }
            return View(docGia);
        }

        // POST: DocGias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DocGia docGia = db.DocGias.Find(id);
            db.DocGias.Remove(docGia);
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
