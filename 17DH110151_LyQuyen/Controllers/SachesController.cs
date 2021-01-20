using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _17DH110151_LyQuyen.Models;

namespace _17DH110151_LyQuyen.Controllers
{
    public class SachesController : Controller
    {
        private CSDL db = new CSDL();

        // GET: Saches
        public ActionResult Index()
        {
            if (Session["KH"] == null || Session["Role"].ToString() != "Admin")
            {
                return RedirectToAction("Login", "KhachHangs");
            }
            var saches = db.Saches.Include(s => s.CongTyPH).Include(s => s.NhaXuatBan).Include(s => s.TacGia).Include(s => s.TheLoai);
            return View(saches.ToList());
        }
        private int Count(IQueryable<Sach> saches)
        {
            decimal a = saches.Count() / 4;
            decimal b = Math.Ceiling(a);
            return Convert.ToInt32(b);
            //return db.Saches.Count() / 4;
        }
        public ActionResult List(int? page, string TenSach,string TenTG,string TenTL)
        {

            IQueryable<Sach> saches = db.Saches.Include(s => s.CongTyPH).Include(s => s.NhaXuatBan).Include(s => s.TacGia).Include(s => s.TheLoai);
            if (!string.IsNullOrEmpty(TenSach))
            {
                saches = saches.Where(s=>s.TenSach.Contains(TenSach));
            }
            if (!string.IsNullOrEmpty(TenTG))
            {
                saches = saches.Where(s => s.TacGia.TenTG.Contains(TenTG));
            }
            if (!string.IsNullOrEmpty(TenTL))
            {
                saches = saches.Where(s => s.TheLoai.TenTL.Contains(TenTL));
            }
            int number = 0;
            if (page != 0)
            {
                number = page.GetValueOrDefault();
            }
            number = page.GetValueOrDefault() * 4;
            ViewBag.count = Count(saches);
            return View(saches.OrderBy(s=>s.MaSach).Skip(number).Take(4).ToList());
        }

        // GET: Saches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: Saches/Create
        public ActionResult Create()
        {
            ViewBag.MaCT = new SelectList(db.CongTyPHs, "MaCT", "TenCT");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNXB");
            ViewBag.MaTG = new SelectList(db.TacGias, "MaTG", "TenTG");
            ViewBag.MaTL = new SelectList(db.TheLoais, "MaTL", "TenTL");
            return View();
        }

        // POST: Saches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,TenSach,MaTL,MaTG,NguoiDich,MaNXB,MaCT,NgonNgu,TrongLuong,KichThuoc,SoTrang,LoaiBia,ItemImageName,NgayXB,NoiDung,Gia")] Sach sach, HttpPostedFileBase ItemImageName)
        {
            if (ModelState.IsValid)
            {
                if (ItemImageName != null)
                {
                    var filename = Path.GetFileName(ItemImageName.FileName);
                    sach.ItemImageName = filename;
                    string path = Path.Combine(Server.MapPath("~/Images"), filename);
                    ItemImageName.SaveAs(path);

                }
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("ShowGrid", "Demo");
            }

            ViewBag.MaCT = new SelectList(db.CongTyPHs, "MaCT", "TenCT", sach.MaCT);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNXB", sach.MaNXB);
            ViewBag.MaTG = new SelectList(db.TacGias, "MaTG", "TenTG", sach.MaTG);
            ViewBag.MaTL = new SelectList(db.TheLoais, "MaTL", "TenTL", sach.MaTL);
            return View(sach);
        }

        // GET: Saches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCT = new SelectList(db.CongTyPHs, "MaCT", "TenCT", sach.MaCT);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNXB", sach.MaNXB);
            ViewBag.MaTG = new SelectList(db.TacGias, "MaTG", "TenTG", sach.MaTG);
            ViewBag.MaTL = new SelectList(db.TheLoais, "MaTL", "TenTL", sach.MaTL);
            return View(sach);
        }

        // POST: Saches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,TenSach,MaTL,MaTG,NguoiDich,MaNXB,MaCT,NgonNgu,TrongLuong,KichThuoc,SoTrang,LoaiBia,ItemImageName,NgayXB,NoiDung,Gia")] Sach sach, HttpPostedFileBase ItemImageName)
        {
            if (ModelState.IsValid)
            {
                if (ItemImageName != null)
                {
                    var filename = Path.GetFileName(ItemImageName.FileName);
                    sach.ItemImageName = filename;
                    string path = Path.Combine(Server.MapPath("~/Images"), filename);
                    ItemImageName.SaveAs(path);

                }
                db.Entry(sach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ShowGrid", "Demo");
            }
            ViewBag.MaCT = new SelectList(db.CongTyPHs, "MaCT", "TenCT", sach.MaCT);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNXB", sach.MaNXB);
            ViewBag.MaTG = new SelectList(db.TacGias, "MaTG", "TenTG", sach.MaTG);
            ViewBag.MaTL = new SelectList(db.TheLoais, "MaTL", "TenTL", sach.MaTL);
            return View(sach);
        }

        // GET: Saches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: Saches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sach sach = db.Saches.Find(id);
            db.Saches.Remove(sach);
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
