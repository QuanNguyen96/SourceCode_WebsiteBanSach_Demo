using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class DangKyDangNhapController : Controller
    {
        QuanLyBanSachEntities6 db = new QuanLyBanSachEntities6();
        // GET: DangKyDangNhap
        public ActionResult DangNhap()
        {
            return PartialView();
        }
        public ActionResult KTraDangNhap(FormCollection f)
        {
            string sTaiKhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = f.Get("txtMatKhau").ToString();
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            TaiKhoanAdmin admin = db.TaiKhoanAdmins.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if (kh != null && admin == null)
            {
                Session["TaiKhoan"] = kh;
                Session["username"] = kh.HoTen;
                return RedirectToAction("Index", "Home");
            }
            if (kh == null && admin != null)
            {
                Session["TaiKhoan"] = admin;
                Session["username"] = admin.HoTen;
                return RedirectToAction("Index", "QuanLySanPham");
            }

            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng";
            return View();
        }
        public ActionResult HienThiTaiKhoan()
        {
            KhachHang kh = (KhachHang)Session["TaiKhoan"];
            return View(kh);
        }
        [HttpGet]
        public ActionResult CapNhatThongTin(int MaKH,FormCollection f)
        {
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.MaKH==MaKH);
            if(kh==null)
            {
                ViewBag.TBB = "Cập nhật thất bại";
                return View();
            }
            return View(kh);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CapNhatThongTin(KhachHang kh, FormCollection f)
        {
            if (kh == null)
            {
                ViewBag.TBB = "Cập nhật thất bại";
                return View();
            }
            kh.MatKhau = f["txtMKK"].ToString();
            if (ModelState.IsValid)
            {
                db.Entry(kh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ViewBag.TBB = "Cập nhật thành công";
            }
            return RedirectToAction("CapNhatThanhCong", "DangKyDangNhap");
        }
        public ActionResult CapNhatThanhCong()
        {
            return View();
        }
    }
}