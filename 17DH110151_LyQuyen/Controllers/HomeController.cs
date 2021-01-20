using _17DH110151_LyQuyen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace _17DH110151_LyQuyen.Controllers
{
    public class HomeController : Controller
    {
        CSDL db = new CSDL();
        public ActionResult Index()
        {
            if (HasConnection()==false)
            {
                return View("asd");
            }
            return View();
        }
        public ActionResult Chart()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ChartCol()
        {
            return View();
        }
        public ActionResult GetData()
        { var ds = db.GioHangs
                 .GroupBy(p => p.Sach.TenSach)
                 .Select(s => new { name = s.Key, y = s.Sum(w => w.SoLuong) }).ToList();
            return Json(ds, JsonRequestBehavior.AllowGet);
        }
        public static bool HasConnection()
        {
            try
            {
                System.Net.IPHostEntry i = System.Net.Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}