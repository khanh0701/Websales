using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbanhang.Context;
namespace Webbanhang.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        MyData data = new MyData();
        public ActionResult Details(int Id)
        {
            var lstSanPham = data.SanPham.Where(n => n.MaSP == Id).FirstOrDefault();
            return View(lstSanPham);
        }
    }
}