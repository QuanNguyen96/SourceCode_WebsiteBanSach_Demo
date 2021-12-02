using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class QuanLyKhachHangController : Controller
    {
        // GET: QuanLyKhachHang
        QuanLyBanSachEntities6 db = new QuanLyBanSachEntities6();
        public ActionResult Index(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(db.KhachHangs.ToList().OrderBy(n => n.MaKH).ToPagedList(pageNumber, pageSize));
        }
        // thêm mới
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(KhachHang KhachHang)
        {
            KhachHang timkiemKhachHang = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == KhachHang.TaiKhoan);
            if (timkiemKhachHang != null)
            {
                ViewBag.ThongBaoKT = "Tên tài khoản đã tồn tại trong cơ sở dữ liệu , xin vui lòng kiểm tra lại !";
                return View();
            }
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(KhachHang);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        // chinh sửa săn phẩm
        [HttpGet]
        public ActionResult ChinhSua(int MaKH)
        {

            KhachHang KhachHang = db.KhachHangs.SingleOrDefault(n => n.MaKH == MaKH);
            if (KhachHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(KhachHang);
        }
        //update dữ liệu chỉnh sửa
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(KhachHang KhachHang, FormCollection f)
        {
            KhachHang timkiemsach = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == KhachHang.TaiKhoan&&n.HoTen==KhachHang.HoTen);
            if (timkiemsach != null)
            {
                KhachHang sachtk = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == KhachHang.TaiKhoan && n.HoTen == KhachHang.HoTen && n.MatKhau == KhachHang.MatKhau && n.Email == KhachHang.Email && n.DiaChi == KhachHang.DiaChi && n.DienThoai == KhachHang.DienThoai && n.GioiTinh == KhachHang.GioiTinh);
                if (sachtk == null)
                {
                    ViewBag.ThongBaoKT = "Tên tài khoản này đã tồn tại trong cơ sở dữ liệu , xin vui lòng kiểm tra lại !";
                    return View(timkiemsach);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            KhachHang.NgaySinh = Convert.ToDateTime(f["txtNgaySinh"].ToString());
            if (ModelState.IsValid)
            {
                db.Entry(KhachHang).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        // thêm mới sách
        public ActionResult HienThi(int MaKH)
        {

            KhachHang KhachHang = db.KhachHangs.SingleOrDefault(n => n.MaKH == MaKH);
            if (KhachHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(KhachHang);
        }
        // xóa sách
        public ActionResult Xoa(int MaKH)
        {

            KhachHang KhachHang = db.KhachHangs.SingleOrDefault(n => n.MaKH == MaKH);
            if (KhachHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(KhachHang);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaKH)
        {
            KhachHang KhachHang = db.KhachHangs.SingleOrDefault(n => n.MaKH == MaKH);
            if (KhachHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<DonHang> timkiemdonhang = db.DonHangs.Where(n => n.MaKH==MaKH).ToList();
            if (timkiemdonhang.Count!=0)
            {
                ViewBag.ThongBaoKT = "Vẫn còn đơn hàng của khách hàng này trong cơ sở dữ liệu , xin vui lòng kiểm tra lại !";
                return View(KhachHang);
            }
            db.KhachHangs.Remove(KhachHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}