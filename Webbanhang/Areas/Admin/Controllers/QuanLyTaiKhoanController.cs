using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbanhang.Context;
namespace Webbanhang.Areas.Admin.Controllers
{
    
    public class QuanLyTaiKhoanController : Controller
    {
        MyData data = new MyData();
        public ActionResult ListTaiKhoan()
        {
            var listtaikhoan = data.TaiKhoan.ToList();
            return View(listtaikhoan);
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
    }
}