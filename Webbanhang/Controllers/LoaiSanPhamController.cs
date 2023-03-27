using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbanhang.Context;

namespace Webbanhang.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        // GET: LoaiSanPham
        MyData data = new MyData();
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult PhanLoaiSanPham(int Id)
        {
            var lstSanPham = data.SanPham.Where(n => n.MaLoaiSP == Id).ToList();
            return View(lstSanPham);
        }
    }
}