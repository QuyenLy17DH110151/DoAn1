using _17DH110151_LyQuyen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17DH110151_LyQuyen.Controllers
{
    public class PayPalController : Controller
    {
        CSDL db = new CSDL();
        // GET: PayPal
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LuuDb()
        {
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
                //LuuDSGioHang(gioHang.SoLuong,item.Sach.Gia);
                db.SaveChanges();
            }
            Session["HD"] = Session["GH"];
            Session.Remove("GH");
            return View("List");
        }
    }
}