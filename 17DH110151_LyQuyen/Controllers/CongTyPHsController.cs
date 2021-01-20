using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _17DH110151_LyQuyen.Models;

namespace _17DH110151_LyQuyen.Controllers
{
    public class CongTyPHsController : Controller
    {
        private CSDL db = new CSDL();

        // GET: CongTyPHs
        public ActionResult Index()
        {
            if (Session["KH"] == null || Session["Role"].ToString() != "Admin")
            {
                return RedirectToAction("Login", "KhachHangs");
            }
            return View(db.CongTyPHs.ToList());
        }

        // GET: CongTyPHs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongTyPH congTyPH = db.CongTyPHs.Find(id);
            if (congTyPH == null)
            {
                return HttpNotFound();
            }
            return View(congTyPH);
        }

        // GET: CongTyPHs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CongTyPHs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCT,TenCT")] CongTyPH congTyPH)
        {
            if (ModelState.IsValid)
            {
                db.CongTyPHs.Add(congTyPH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(congTyPH);
        }

        // GET: CongTyPHs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongTyPH congTyPH = db.CongTyPHs.Find(id);
            if (congTyPH == null)
            {
                return HttpNotFound();
            }
            return View(congTyPH);
        }

        // POST: CongTyPHs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCT,TenCT")] CongTyPH congTyPH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(congTyPH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(congTyPH);
        }

        // GET: CongTyPHs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongTyPH congTyPH = db.CongTyPHs.Find(id);
            if (congTyPH == null)
            {
                return HttpNotFound();
            }
            return View(congTyPH);
        }

        // POST: CongTyPHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CongTyPH congTyPH = db.CongTyPHs.Find(id);
            db.CongTyPHs.Remove(congTyPH);
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
