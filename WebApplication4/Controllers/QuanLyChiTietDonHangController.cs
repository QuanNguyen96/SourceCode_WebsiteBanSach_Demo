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
    public class QuanLyChiTietDonHangController : Controller
    {
        // GET: ChiTietDonHang
        QuanLyBanSachEntities6 db = new QuanLyBanSachEntities6();
        public ActionResult Index(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(db.ChiTietDonHangs.ToList().OrderBy(n => n.MaDonHang).ToPagedList(pageNumber, pageSize));
        }
        // thêm mới
        [HttpGet]
        public ActionResult ThemMoi()
        {
            ViewBag.MaDonHang = new SelectList(db.DonHangs.ToList().OrderBy(n => n.MaDonHang), "MaDonHang", "MaDonHang");
            ViewBag.MaSach = new SelectList(db.Saches.ToList().OrderBy(n => n.MaSach), "MaSach", "TenSach");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(ChiTietDonHang ctDH)
        {
            ViewBag.MaDonHang = new SelectList(db.DonHangs.ToList().OrderBy(n => n.MaDonHang), "MaDonHang", "MaDonHang",ctDH.MaDonHang);
            ViewBag.MaSach = new SelectList(db.Saches.ToList().OrderBy(n => n.MaSach), "MaSach", "TenSach",ctDH.MaSach);
            Sach sachtk = db.Saches.SingleOrDefault(n => n.MaSach == ctDH.MaSach);
            ctDH.DonGia = sachtk.GiaBan.ToString();
            if(ctDH.SoLuong==null||int.Parse(ctDH.SoLuong.ToString())<=0)
            {
                return View(ctDH);
            }
            if (ModelState.IsValid)
            {
                db.ChiTietDonHangs.Add(ctDH);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        // chinh sửa săn phẩm
        [HttpGet]
        public ActionResult ChinhSua(int MaDH,int MaSach)
        {
            ChiTietDonHang ctDH = db.ChiTietDonHangs.SingleOrDefault(n => n.MaDonHang == MaDH&&n.MaSach==MaSach);
            if (ctDH == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaDonHang = new SelectList(db.DonHangs.ToList().OrderBy(n => n.MaDonHang), "MaDonHang", "MaDonHang", ctDH.MaDonHang);
            ViewBag.MaSach = new SelectList(db.Saches.ToList().OrderBy(n => n.MaSach), "MaSach", "TenSach", ctDH.MaSach);
            return View(ctDH);
        }
        //update dữ liệu chỉnh sửa
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(ChiTietDonHang ctDH, FormCollection f)
        {
            ViewBag.MaDonHang = new SelectList(db.DonHangs.ToList().OrderBy(n => n.MaDonHang), "MaDonHang", "MaDonHang", ctDH.MaDonHang);
            ViewBag.MaSach = new SelectList(db.Saches.ToList().OrderBy(n => n.MaSach), "MaSach", "TenSach", ctDH.MaSach);
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == ctDH.MaSach);
            ctDH.DonGia = sach.GiaBan.ToString();
            if (ModelState.IsValid)
            {
                db.Entry(ctDH).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        // thêm mới sách
        public ActionResult HienThi(int MaDH, int MaSach)
        {

            ChiTietDonHang ctDH = db.ChiTietDonHangs.SingleOrDefault(n => n.MaDonHang == MaDH && n.MaSach == MaSach);
            if (ctDH == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ctDH);
        }
        // xóa sách
        public ActionResult Xoa(int MaDH, int MaSach)
        {

            ChiTietDonHang ctDH = db.ChiTietDonHangs.SingleOrDefault(n => n.MaDonHang == MaDH && n.MaSach == MaSach);
            if (ctDH == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ctDH);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaDH, int MaSach)
        {

            ChiTietDonHang ctDH = db.ChiTietDonHangs.SingleOrDefault(n => n.MaDonHang == MaDH && n.MaSach == MaSach);
            if (ctDH == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.ChiTietDonHangs.Remove(ctDH);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}