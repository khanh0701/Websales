using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webbanhang.Context;
using System.Web.Mvc;

namespace Webbanhang.Areas.Admin.Controllers
{
    public class QuanLyDonHangController : Controller
    {
        MyData data = new MyData();
        public ActionResult ListDonHang()
        {
            var listdonhang = data.DonHang.ToList();
            return View(listdonhang);
        }

        public ActionResult Delete(int id)
        {
            var D_DonHang = data.DonHang.First(m => m.MaDH == id);
            return View(D_DonHang);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_DonHang = data.DonHang.Where(m => m.MaDH == id).First();
            data.DonHang.Remove(D_DonHang);
            data.SaveChanges();
            return RedirectToAction("ListDonHang");
        }
    }
}