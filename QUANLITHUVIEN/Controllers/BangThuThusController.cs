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
    public class BangThuThusController : Controller
    {
        private QUANLITHUVIENDbContext db = new QUANLITHUVIENDbContext();

        // GET: BangThuThus
        public ActionResult Index()
        {
            return View(db.BangThuThus.ToList());
        }

        // GET: BangThuThus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangThuThu bangThuThu = db.BangThuThus.Find(id);
            if (bangThuThu == null)
            {
                return HttpNotFound();
            }
            return View(bangThuThu);
        }

        // GET: BangThuThus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BangThuThus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaThuThu,TenThuThu,DiaChi")] BangThuThu bangThuThu)
        {
            if (ModelState.IsValid)
            {
                db.BangThuThus.Add(bangThuThu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bangThuThu);
        }

        // GET: BangThuThus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangThuThu bangThuThu = db.BangThuThus.Find(id);
            if (bangThuThu == null)
            {
                return HttpNotFound();
            }
            return View(bangThuThu);
        }

        // POST: BangThuThus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaThuThu,TenThuThu,DiaChi")] BangThuThu bangThuThu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bangThuThu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bangThuThu);
        }

        // GET: BangThuThus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangThuThu bangThuThu = db.BangThuThus.Find(id);
            if (bangThuThu == null)
            {
                return HttpNotFound();
            }
            return View(bangThuThu);
        }

        // POST: BangThuThus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BangThuThu bangThuThu = db.BangThuThus.Find(id);
            db.BangThuThus.Remove(bangThuThu);
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
