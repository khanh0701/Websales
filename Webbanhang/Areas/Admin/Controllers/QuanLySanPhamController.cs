using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbanhang.Context;

namespace Webbanhang.Areas.Admin.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        
        MyData data = new MyData();
        public ActionResult ListSanPham()
        {
            var all_sanpham = from ss in data.SanPham select ss;
            return View(all_sanpham);
        }

        public ActionResult AoKhoac()
        {
            var aokhoac_danhmucsanpham = data.SanPham.Where(m => m.MaLoaiSP == 1);
            return View(aokhoac_danhmucsanpham);
        }
        public ActionResult AoThun()
        {
            var aothun_danhmucsanpham = data.SanPham.Where(m => m.MaLoaiSP == 2);
            return View(aothun_danhmucsanpham);
        }
        public ActionResult AoSoMi()
        {
            var aosomi_danhmucsanpham = data.SanPham.Where(m => m.MaLoaiSP == 3);
            return View(aosomi_danhmucsanpham);
        }
        public ActionResult QuanShort()
        {
            var quanshort_danhmucsanpham = data.SanPham.Where(m => m.MaLoaiSP == 4);
            return View(quanshort_danhmucsanpham);
        }
        public ActionResult QuanTay()
        {
            var quantay_danhmucsanpham = data.SanPham.Where(m => m.MaLoaiSP == 5);
            return View(quantay_danhmucsanpham);
        }
        public ActionResult QuanKaki()
        {
            var quankaki_danhmucsanpham = data.SanPham.Where(m => m.MaLoaiSP == 6);
            return View(quankaki_danhmucsanpham);
        }
        public ActionResult Giay()
        {
            var giay_danhmucsanpham = data.SanPham.Where(m => m.MaLoaiSP == 7);
            return View(giay_danhmucsanpham);
        }
        public ActionResult Balo()
        {
            var balo_danhmucsanpham = data.SanPham.Where(m => m.MaLoaiSP == 8);
            return View(balo_danhmucsanpham);
        }

        public ActionResult Detail(int id)
        {
            var detail_sanpham = data.SanPham.Where(m => m.MaSP == id).First();
            return View(detail_sanpham);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SanPham TT)
        {
            var E_tensp = collection["TenSP"];
            var E_mota1 = collection["MoTa1"];
            var E_mota2 = collection["MoTa2"];
            var E_hinh = collection["Hinh"];
            var E_giaban = Convert.ToDecimal(collection["GiaBan"]);
            var E_ngaycapnhat = Convert.ToDateTime(collection["NgayCapNhat"]);
            var E_soluongton = Convert.ToInt32(collection["SoLuongTon"]);
            var E_maloaisp = Convert.ToInt32(collection["MaLoaiSP"]);
            var E_manhacc = Convert.ToInt32(collection["MaNCC"]);
            if (string.IsNullOrEmpty(E_tensp))
            {
                ViewData["Error"] = "Don't Empty!!!";
            }
            else
            {
                TT.TenSP = E_tensp.ToString();
                TT.MoTa1 = E_mota1.ToString();
                TT.MoTa2 = E_mota2.ToString();
                TT.Hinh = E_hinh.ToString();
                TT.GiaBan = E_giaban;
                TT.NgayCapNhat = E_ngaycapnhat;       
                TT.SoLuongTon = E_soluongton;
                TT.MaLoaiSP = E_maloaisp;
                TT.MaNCC = E_manhacc;
                data.SanPham.Add(TT);
                data.SaveChanges();
                return RedirectToAction("ListSanPham");
            }
            return View();
        }
        public string ProcessUpLoad(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Areas/Admin/AssetsAD/images/" + file.FileName));
            return "/Areas/Admin/AssetsAD/images/" + file.FileName;
        }
        public ActionResult Detele(int id)
        {
            var D_sanpham = data.SanPham.First(m => m.MaSP == id);
            return View(D_sanpham);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_sanpham = data.SanPham.Where(m => m.MaSP == id).First();
            data.SanPham.Remove(D_sanpham);
            data.SaveChanges();
            return RedirectToAction("ListSanPham");
        }
        public ActionResult Edit(int id)
        {
            var E_sanpham = data.SanPham.First(m => m.MaSP == id);
            return View(E_sanpham);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_sanpham = data.SanPham.First(m => m.MaSP == id);
            var E_tensp = collection["TenSP"];
            var E_mota1 = collection["MoTa1"];
            var E_mota2 = collection["MoTa2"];
            var E_ngaycapnhat = Convert.ToDateTime(collection["NgayCatNhat"]);
            var E_giaban = Convert.ToDecimal(collection["GiaBan"]);
            var E_hinh = collection["Hinh"];
            var E_soluongton = Convert.ToInt32(collection["SoLuongTon"]);
            var E_maloaisp = Convert.ToInt32(collection["MaLoaiSP"]);
            var E_manhacc = Convert.ToInt32(collection["MaNCC"]);
            E_sanpham.MaSP = id;
            if (string.IsNullOrEmpty(E_tensp))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_sanpham.TenSP = E_tensp.ToString();
                E_sanpham.MoTa1 = E_mota1.ToString();
                E_sanpham.MoTa2 = E_mota2.ToString();
                E_sanpham.NgayCapNhat = E_ngaycapnhat;
                E_sanpham.GiaBan = E_giaban;
                E_sanpham.Hinh = E_hinh.ToString();
                E_sanpham.SoLuongTon = E_soluongton;
                E_sanpham.MaLoaiSP = E_maloaisp;
                E_sanpham.MaNCC = E_manhacc;
                UpdateModel(E_sanpham);
                data.SaveChanges();
                return RedirectToAction("ListSanPham");
            }
            return this.Edit(id);
        }
    }
}