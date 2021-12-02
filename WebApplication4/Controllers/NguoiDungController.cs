using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        QuanLyBanSachEntities6 db = new QuanLyBanSachEntities6();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DangKy(KhachHang kh, FormCollection f)
        {
            KhachHang timkiemKhachHang = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == kh.TaiKhoan);
            if (timkiemKhachHang != null)
            {
                ViewBag.ThongBaoKT = "Tên tài khoản đã tồn tại trong cơ sở dữ liệu , xin vui lòng kiểm tra lại !";
                return View();
            }
            if(f["txtMK"].ToString()!=null && f["txtMK"].ToString() != "")
            {
                kh.MatKhau = f["txtMK"].ToString();
            }
            else
            {
                ViewBag.TB = "Chưa nhập mật khẩu ";
                return View();
            }
            if (ModelState.IsValid)
            {
                Session["TKDk"] = kh.TaiKhoan;
                Session["MKDK"] = kh.MatKhau;
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                return RedirectToAction("DangNhap","DangKyDangNhap");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
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
        public ActionResult Thoat()
        {
            Session["TaiKhoan"] = null;
            Session["username"] = null;
            Session["TKDk"] = null;
            Session["MKDK"] = null;
            Session["GioHang"] = "";
            return RedirectToAction("Index","Home");
        }
    }
}