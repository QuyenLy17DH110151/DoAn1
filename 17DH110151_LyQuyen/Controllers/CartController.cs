using _17DH110151_LyQuyen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17DH110151_LyQuyen.Controllers
{
    public class CartController : Controller
    {
        CSDL db = new CSDL();
        public ActionResult Index()
        {
            if (Session["GH"] == null)
            {
                List<GioHang> gh = new List<GioHang>();
                Session["GH"] = gh;
            }
            return View();
        }
       
        public ActionResult ThemGioHang(int id)
        {
            var item = db.Saches.Find(id);
            if (Session["GH"] == null)
            {
                List<GioHang> gh = new List<GioHang>();
                gh.Add(new GioHang(item, 1));
                Session["GH"] = gh;
            }
            else
            {
                List<GioHang> gh = (List<GioHang>)Session["GH"];
                int vt = exists(id);
                if (vt == -1)
                {
                    gh.Add(new GioHang(item, 1));
                }
                else
                {
                    gh[vt].SoLuong++;
                }
                Session["GH"] = gh;
            }
            return View("index");
        }

        private int exists(int id)
        {
            List<GioHang> gh = (List<GioHang>)Session["GH"];
            for (int i = 0; i < gh.Count; i++)
            {
                if (gh[i].Sach.MaSach.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        public ActionResult Xoa(int id)
        {
            List<GioHang> gh = (List<GioHang>)Session["GH"];
            int index = exists(id);
            gh.RemoveAt(index);
            Session["GH"] = gh;
            return View("Index");
        }
        public ActionResult Buy()
        {
            if (Session["KH"] == null)
            {
                return RedirectToAction("Login", "KhachHangs");
            }
            GioHang gioHang = new GioHang();
            int MaKH = Convert.ToInt32(Session["MaKH"]);
            var kh = db.KhachHangs.Where(s => s.MaKH.Equals(MaKH)).FirstOrDefault();
            foreach (var item in (List<GioHang>)Session["GH"])
            {
                var sach = db.Saches.Where(s => s.MaSach.Equals(item.Sach.MaSach)).FirstOrDefault();
                gioHang.Sach = sach;
                gioHang.SoLuong = item.SoLuong;
                gioHang.KhachHang = kh;
                gioHang.NgayMua = DateTime.Now;
                db.GioHangs.Add(gioHang);
                db.SaveChanges();
            }
            Session["HD"] = Session["GH"];
            Session.Remove("GH");
            return View("List");
        }

        public ActionResult List()
        {
            return View();
        }
    }
}