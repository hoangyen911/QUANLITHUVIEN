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
    public class MuonTrasController : Controller
    {
        private QUANLITHUVIENDbContext db = new QUANLITHUVIENDbContext();

        // GET: MuonTras
        public ActionResult Index()
        {
            return View(db.MuonTras.ToList());
        }

        // GET: MuonTras/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MuonTra muonTra = db.MuonTras.Find(id);
            if (muonTra == null)
            {
                return HttpNotFound();
            }
            return View(muonTra);
        }

        // GET: MuonTras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MuonTras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoThuTu,SoThe,NgayMuon,NgayTra,NgayPhaiTra,MaSach,MaThuThu")] MuonTra muonTra)
        {
            if (ModelState.IsValid)
            {
                db.MuonTras.Add(muonTra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(muonTra);
        }

        // GET: MuonTras/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MuonTra muonTra = db.MuonTras.Find(id);
            if (muonTra == null)
            {
                return HttpNotFound();
            }
            return View(muonTra);
        }

        // POST: MuonTras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoThuTu,SoThe,NgayMuon,NgayTra,NgayPhaiTra,MaSach,MaThuThu")] MuonTra muonTra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(muonTra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(muonTra);
        }

        // GET: MuonTras/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MuonTra muonTra = db.MuonTras.Find(id);
            if (muonTra == null)
            {
                return HttpNotFound();
            }
            return View(muonTra);
        }

        // POST: MuonTras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MuonTra muonTra = db.MuonTras.Find(id);
            db.MuonTras.Remove(muonTra);
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
