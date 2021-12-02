using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace WebApplication4.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        // GET: QuanLySanPham
        QuanLyBanSachEntities6 db = new QuanLyBanSachEntities6();
        NguoiDungController nd = new NguoiDungController();
        public ActionResult Index(int? page)
        {
            try
            {
                if (Session["taikhoan"]==null||Session["taikhoan"]=="")
                {
                    Response.StatusCode = 404;
                    return null;
                }
            }catch {
                Response.StatusCode = 404;
                return null;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.Saches.ToList().OrderBy(n => n.MaSach).ToPagedList(pageNumber, pageSize));
        }
        // thêm mới
        [HttpGet]
        public ActionResult ThemMoi()
        {
            try
            {
                if (Session["taikhoan"] == null || Session["taikhoan"] == "")
                {
                    Response.StatusCode = 404;
                    return null;
                }
            }
            catch
            {
                Response.StatusCode = 404;
                return null;
            }
            // đưa dữ liệu vào dropdownlist
            ViewBag.MaChuDe = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(Sach sach, HttpPostedFileBase fileUpload)
        {
            ViewBag.MaChuDe = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            Sach timkiemsach = db.Saches.SingleOrDefault(n => n.TenSach == sach.TenSach);
            if(timkiemsach != null)
            {
                ViewBag.ThongBaoKT = "Tên sách đã tồn tại trong cơ sở dữ liệu , xin vui lòng kiểm tra lại !";
                return View();
            }

            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Chưa chọn hình ảnh !";
                return View();
            }
            if (ModelState.IsValid)
            {
                // lưu tên
                var fileName = Path.GetFileName(fileUpload.FileName);
                // lưu đường dẫn
                var path = Path.Combine(Server.MapPath("~/HinhAnhSP"), fileName);
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại !";
                }
                else
                {
                    fileUpload.SaveAs(path);
                }
                sach.AnhBia = fileUpload.FileName;
                db.Saches.Add(sach);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        // chinh sửa săn phẩm
        [HttpGet]
        public ActionResult ChinhSua(int MaSach)
        {
            try
            {
                if (Session["taikhoan"] == null || Session["taikhoan"] == "")
                {
                    Response.StatusCode = 404;
                    return null;
                }
            }
            catch
            {
                Response.StatusCode = 404;
                return null;
            }
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaChuDe = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe",sach.MaChuDe);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB",sach.MaNXB);
            return View(sach);
        }
        //update dữ liệu chỉnh sửa
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(Sach sach, HttpPostedFileBase fileUpload,FormCollection f)
        {
            ViewBag.MaChuDe = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe", sach.MaChuDe);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB", sach.MaNXB);
            Sach timkiemsach = db.Saches.SingleOrDefault(n => n.TenSach == sach.TenSach);
            if (timkiemsach != null)
            {
                Sach sachtk = db.Saches.SingleOrDefault(n => n.TenSach == sach.TenSach && n.MaChuDe == sach.MaChuDe && n.MaNXB == sach.MaNXB && n.MoTa == sach.MoTa && n.GiaBan == sach.GiaBan);
                if (sachtk == null)
                {
                    ViewBag.ThongBaoKT = "Tên sách đã tồn tại trong cơ sở dữ liệu , xin vui lòng kiểm tra lại !";
                    return View(timkiemsach);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                if (fileUpload != null)
                {
                    // lưu tên
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    // lưu đường dẫn
                    var path = Path.Combine(Server.MapPath("~/HinhAnhSP"), fileName);
                    if (System.IO.File.Exists(path))
                    {

                    }
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    sach.AnhBia = fileUpload.FileName;
                    if (ModelState.IsValid)
                    {
                        db.Entry(sach).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                else
                {
                    string sMatKhau = f.Get("abc").ToString();
                    sach.AnhBia = sMatKhau;
                    if (ModelState.IsValid)
                    {
                        db.Entry(sach).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index");
        }
        // thêm mới sách
        public ActionResult HienThi(int MaSach)
        {
            try
            {
                if (Session["taikhoan"] == null || Session["taikhoan"] == "")
                {
                    Response.StatusCode = 404;
                    return null;
                }
            }
            catch
            {
                Response.StatusCode = 404;
                return null;
            }
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
        // xóa sách
        public ActionResult Xoa(int MaSach)
        {
            try
            {
                if (Session["taikhoan"] == null || Session["taikhoan"] == "")
                {
                    Response.StatusCode = 404;
                    return null;
                }
            }
            catch
            {
                Response.StatusCode = 404;
                return null;
            }
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
        [HttpPost,ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaSach)
        {

            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.Saches.Remove(sach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}