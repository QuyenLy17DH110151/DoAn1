﻿using System;
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
    public class NhaXuatBansController : Controller
    {
        private CSDL db = new CSDL();

        // GET: NhaXuatBans
        public ActionResult Index()
        {
            if (Session["KH"] == null || Session["Role"].ToString() != "Admin")
            {
                return RedirectToAction("Login", "KhachHangs");
            }
            return View(db.NhaXuatBans.ToList());
        }

        // GET: NhaXuatBans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaXuatBan nhaXuatBan = db.NhaXuatBans.Find(id);
            if (nhaXuatBan == null)
            {
                return HttpNotFound();
            }
            return View(nhaXuatBan);
        }

        // GET: NhaXuatBans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhaXuatBans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNXB,TenNXB")] NhaXuatBan nhaXuatBan)
        {
            if (ModelState.IsValid)
            {
                db.NhaXuatBans.Add(nhaXuatBan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhaXuatBan);
        }

        // GET: NhaXuatBans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaXuatBan nhaXuatBan = db.NhaXuatBans.Find(id);
            if (nhaXuatBan == null)
            {
                return HttpNotFound();
            }
            return View(nhaXuatBan);
        }

        // POST: NhaXuatBans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNXB,TenNXB")] NhaXuatBan nhaXuatBan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhaXuatBan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhaXuatBan);
        }

        // GET: NhaXuatBans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaXuatBan nhaXuatBan = db.NhaXuatBans.Find(id);
            if (nhaXuatBan == null)
            {
                return HttpNotFound();
            }
            return View(nhaXuatBan);
        }

        // POST: NhaXuatBans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhaXuatBan nhaXuatBan = db.NhaXuatBans.Find(id);
            db.NhaXuatBans.Remove(nhaXuatBan);
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
