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
    public class DangKyCaBietsController : Controller
    {
        private QUANLITHUVIENDbContext db = new QUANLITHUVIENDbContext();
        [Authorize]
        // GET: DangKyCaBiets
        public ActionResult Index()
        {
            return View(db.DangKyCaBiets.ToList());
        }

        // GET: DangKyCaBiets/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DangKyCaBiet dangKyCaBiet = db.DangKyCaBiets.Find(id);
            if (dangKyCaBiet == null)
            {
                return HttpNotFound();
            }
            return View(dangKyCaBiet);
        }

        // GET: DangKyCaBiets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DangKyCaBiets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,SoDangKy,NgayVaoSo,MaKho")] DangKyCaBiet dangKyCaBiet)
        {
            if (ModelState.IsValid)
            {
                db.DangKyCaBiets.Add(dangKyCaBiet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dangKyCaBiet);
        }

        // GET: DangKyCaBiets/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DangKyCaBiet dangKyCaBiet = db.DangKyCaBiets.Find(id);
            if (dangKyCaBiet == null)
            {
                return HttpNotFound();
            }
            return View(dangKyCaBiet);
        }

        // POST: DangKyCaBiets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,SoDangKy,NgayVaoSo,MaKho")] DangKyCaBiet dangKyCaBiet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dangKyCaBiet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dangKyCaBiet);
        }

        // GET: DangKyCaBiets/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DangKyCaBiet dangKyCaBiet = db.DangKyCaBiets.Find(id);
            if (dangKyCaBiet == null)
            {
                return HttpNotFound();
            }
            return View(dangKyCaBiet);
        }

        // POST: DangKyCaBiets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DangKyCaBiet dangKyCaBiet = db.DangKyCaBiets.Find(id);
            db.DangKyCaBiets.Remove(dangKyCaBiet);
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
