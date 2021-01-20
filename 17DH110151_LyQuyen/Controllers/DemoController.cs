using _17DH110151_LyQuyen.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Linq.Dynamic;
using System.Data.Entity;

namespace _17DH110151_LyQuyen.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult ShowGrid()
        {
            if (Session["KH"] == null || Session["Role"].ToString() != "Admin")
            {
                return RedirectToAction("Login", "KhachHangs");
            }
            return View();
        }

        public ActionResult LoadData()
        {
            try
            {
                //Creating instance of DatabaseContext class
                using (CSDL db = new CSDL())
                {
                    var draw = Request.Form.GetValues("draw").FirstOrDefault();
                    var start = Request.Form.GetValues("start").FirstOrDefault();
                    var length = Request.Form.GetValues("length").FirstOrDefault();
                    var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                    var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                    var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();


                    //Paging Size (10,20,50,100)  
                    int pageSize = length != null ? Convert.ToInt32(length) : 0;
                    int skip = start != null ? Convert.ToInt32(start) : 0;
                    int recordsTotal = 0;

                    // Getting all Customer data  
                    var saches = db.Saches.Include(s => s.CongTyPH).Include(s => s.NhaXuatBan).Include(s => s.TacGia).Include(s => s.TheLoai);

                    //Sorting  
                    if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                    {
                        saches = saches.OrderBy(sortColumn + " " + sortColumnDir);
                    }

                    //Search  
                    if (!string.IsNullOrEmpty(searchValue))
                    {
                        saches = saches.Where(m => m.TenSach.Contains(searchValue));
                    }

                    //total number of rows count   
                    recordsTotal = saches.Count();
                    //Paging   
                    var data = saches.Skip(skip).Take(pageSize).ToList();
                    //Returning Json Data  
                    return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}